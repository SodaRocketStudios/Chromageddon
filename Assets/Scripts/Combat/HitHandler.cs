using System;
using UnityEngine;
using SRS.Stats;
using Cinemachine;
using UnityEngine.Events;

namespace SRS.Combat
{
	public class HitHandler : MonoBehaviour
	{
		public Action<float> OnHit;

		public Action<StatContainer> TryHitEffects;

		public UnityEvent OnDodge;

		[SerializeField] private Health health = new();

		[SerializeField] private float immunityTime;
		private float lastHitTime = 0;

		[SerializeField] private AudioClip hitSound;
		[SerializeField] private AudioClip critSound;

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

		private AudioSource audioSource;

		private void Awake()
		{
			stats = GetComponent<StatContainer>();
			impulseSource = GetComponent<CinemachineImpulseSource>();
			audioSource = GetComponent<AudioSource>();
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
			if(DamageCalculator.CheckDodge(stats["Dodge"].Value))
			{
				OnDodge?.Invoke();
				return;
			}

			float damage = attackerStats["Damage"].Value;

			if(DamageCalculator.CheckCritical(attackerStats["Critical Chance"].Value))
			{
				audioSource.PlayOneShot(critSound);
				damage *= attackerStats["Critical Damage"].Value;
			}
			
			Hit(damage, damageType);

			TryHitEffects?.Invoke(attackerStats);
		}

		public void Hit(float damage, DamageType damageType)
		{
			if(Time.time - lastHitTime > immunityTime)
			{
				// TODO -- make sure not to check dodge twice.
				// if(DamageCalculator.CheckDodge(stats["Dodge"].Value))
				// {
				// 	OnDodge?.Invoke();
				// 	return;
				// }

				if(impulseSource != null)
				{
					impulseSource.m_ImpulseDefinition = hitImpulse;
					impulseSource.GenerateImpulse(impulseMagnitude);
				}

				audioSource?.PlayOneShot(hitSound);

				damage = DamageCalculator.Calculate(damage, stats, damageType);

				ApplyDamage(damage, damageType);
				lastHitTime = Time.time;
			}
		}

		private void ApplyDamage(float amount, DamageType damageType)
		{
			health.Damage(amount, damageType);

			OnHit?.Invoke(amount);
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