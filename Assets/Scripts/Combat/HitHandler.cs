using System;
using UnityEngine;
using SRS.Stats;
using Cinemachine;
using System.Numerics;

namespace SRS.Combat
{
	public class HitHandler : MonoBehaviour
	{
		public Action<float> OnHit;

		public Action<StatContainer> TryHitEffects;

		[SerializeField] private Health health = new();

		[SerializeField] private float immunityTime;
		private float lastHitTime = 0;

		[SerializeField] private CinemachineImpulseDefinition hitImpulse;
		[SerializeField] private float impulseMagnitude;
		private CinemachineImpulseSource impulseSource;

		public Health Health
		{
			get
			{
				return health;
			}
		}

		private StatContainer stats;

		private void Awake()
		{
			stats = GetComponent<StatContainer>();
			impulseSource = GetComponent<CinemachineImpulseSource>();
		}

		private void Start()
		{
			Initialize();
		}

		public void Initialize()
		{
			health.Value.Max = stats["Health"].Value;
			health.Value.SetCurrentToMax();
			stats["Health"].OnChanged += HandleHealthChange;
		}

		public void Hit(StatContainer attackerStats, DamageType damageType)
		{
			Hit(attackerStats["Damage"].Value, damageType);

			TryHitEffects?.Invoke(attackerStats);
		}

		public void Hit(float damage, DamageType damageType)
		{
			if(Time.time - lastHitTime > immunityTime)
			{
				if(impulseSource != null)
				{
					impulseSource.m_ImpulseDefinition = hitImpulse;
					impulseSource.GenerateImpulse(impulseMagnitude);
				}

				damage = DamageCalculator.Calculate(damage, stats, damageType);

				ApplyDamage(damage, damageType);
				lastHitTime = Time.time;
			}
		}

		private void ApplyDamage(float amount, DamageType damageType)
		{
			health.Damage(amount, damageType);

			OnHit?.Invoke(amount); // Might make more sense for shield and health to handle most of these events
		}

		private void HandleHealthChange(float newMax)
		{
			if(newMax <= 0)
			{
				health.FilledChange(1);
			}
			
			health.FilledChange(newMax);
		}
	}
}