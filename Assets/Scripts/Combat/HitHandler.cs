using System;
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

		private HitEffectDatabase hitEffectDatabase;

		private System.Random random = new(Guid.NewGuid().GetHashCode());

		private void Awake()
		{
			stats = GetComponent<StatContainer>();
			health = GetComponent<Health>();

			hitEffectDatabase = FindAnyObjectByType<HitEffectDatabase>();
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
			health.Damage(amount, damageType);

			OnHit?.Invoke(0); // Might make more sense for shield and health to handle most of these events
		}

		private void TryOnHitEffects(StatContainer attackerStats)
		{
			foreach(IOnHitEffect effect in hitEffectDatabase.Effects)
			{
				// TODO -- Try to apply effects
				// if random < proc chance
				// effect.Trigger(stats)
			}
		}
	}
}