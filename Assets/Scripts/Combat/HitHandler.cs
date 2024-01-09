using System;
using UnityEngine;
using UnityEngine.Events;
using SRS.Stats;
using SRS.Extensions.Random;

namespace SRS.Combat
{
	public class HitHandler : MonoBehaviour
	{
		public UnityEvent<float> OnHit;

		private StatContainer stats;

		[SerializeField] private Health health;
		public Health Health
		{
			get
			{
				return health;
			}
		}

		private System.Random random = new(Guid.NewGuid().GetHashCode());

		private void Awake()
		{
			stats = GetComponent<StatContainer>();
		}

		private void Start()
		{
			health = new(stats["Health"].Value);
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
			foreach(IOnHitEffect effect in HitEffectDatabase.Effects)
			{
				float procCheck = random.NextFloat()*100;
				
				if(procCheck <= attackerStats[effect.ProcStat].Value)
				{
					effect.Trigger(gameObject);
				}
			}
		}
	}
}