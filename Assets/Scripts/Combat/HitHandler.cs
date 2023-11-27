using UnityEngine;
using UnityEngine.Events;
using SRS.Stats;

namespace SRS.Combat
{
	public class HitHandler : MonoBehaviour
	{
		public UnityEvent<float> OnHit;

		private StatContainer stats;
		private Health health;
		private Shield shield;

		private void Awake()
		{
			stats = GetComponent<StatContainer>();
			health = GetComponent<Health>();
			shield = GetComponent<Shield>();
		}

		public void Hit(StatContainer attackerStats, DamageType damageType)
		{
			ApplyDamage(attackerStats["Damage"].Value, damageType);

			TryOnHitEffects(attackerStats);
		}

		public void Hit(float damage, DamageType damageType)
		{
			ApplyDamage(damage, damageType);
		}

		private void ApplyDamage(float amount, DamageType damageType)
		{
			float remainingDamage = shield.Damage(amount, damageType);

			health.Damage(remainingDamage, damageType);

			OnHit?.Invoke(0); // Might make more sense for shield and health to handle most of these events
		}

		private void TryOnHitEffects(StatContainer attackerStats)
		{
			// Try all on hit effects.
		}
	}
}