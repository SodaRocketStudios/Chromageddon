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
			float remainingDamage = shield.Damage(attackerStats["Damage"].Value, damageType);

			health.Damage(remainingDamage, damageType);

			OnHit?.Invoke(0); // Might make more sense for shield and health to handle most of these events

			TryOnHitEffects(attackerStats);
		}

		public void Hit(DamageType damageType)
		{

		}

		private void TryOnHitEffects(StatContainer attackerStats)
		{
			// Try all on hit effects.
		}
	}
}