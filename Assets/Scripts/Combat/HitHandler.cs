using System;
using UnityEngine;
using UnityEngine.Events;
using SRS.Stats;

namespace SRS.Combat
{
	public class HitHandler : MonoBehaviour
	{
		public UnityEvent<float> OnHit;

		public Action<StatContainer> TryHitEffects;

		[SerializeField] private Health health;

		private StatContainer stats;

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

			TryHitEffects?.Invoke(attackerStats);
		}

		public void Hit(float damage, DamageType damageType)
		{
			ApplyDamage(damage, damageType);
		}

		private void ApplyDamage(float amount, DamageType damageType)
		{
			health.Damage(amount, damageType);

			OnHit?.Invoke(amount); // Might make more sense for shield and health to handle most of these events
		}
	}
}