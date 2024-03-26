using System;
using UnityEngine;
using SRS.Stats;
using Cinemachine;
using UnityEngine.Events;
using SRS.Utils.VFX;
using SRS.Statistics;
using SRS.Audio;

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

		// [SerializeField] private AudioClip hitSound;
		// [SerializeField] private AudioClip critSound;

		[SerializeField] private Sound hitSound;
		[SerializeField] private Sound critSound;

		[SerializeField] private ParticleManager critParticles;
		[SerializeField] private ParticleManager dodgeParticles;

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
			if(Time.time - lastHitTime < immunityTime)
			{
				return;
			}

			if(DamageCalculator.CheckDodge(stats["Dodge"].Value))
			{
				OnDodge?.Invoke();
				dodgeParticles?.PlayParticles(transform.position, Quaternion.identity);
				lastHitTime = Time.time;
				return;
			}

			float damage = attackerStats["Damage"].Value;

			if(DamageCalculator.CheckCritical(attackerStats["Critical Chance"].Value))
			{
				AudioManager.Instance.Play(critSound);
				// audioSource.PlayOneShot(critSound);
				damage *= attackerStats["Critical Damage"].Value;

				if(!gameObject.CompareTag("Player"))
				{
					StatisticManager.Instance["Criticals"].Value++;
				}

				critParticles?.PlayParticles(transform.position, Quaternion.identity, Color.red);
			}
			
			Hit(damage, damageType);

			TryHitEffects?.Invoke(attackerStats);
		}

		public void Hit(float damage, DamageType damageType)
		{
			if(Time.time - lastHitTime < immunityTime)
			{
				return;
			}
			
			if(impulseSource != null)
			{
				impulseSource.m_ImpulseDefinition = hitImpulse;
				impulseSource.GenerateImpulse(impulseMagnitude);
			}

			if(hitSound != null)
			{
				AudioManager.Instance.Play(hitSound);
				// audioSource?.PlayOneShot(hitSound);
			}

			damage = DamageCalculator.Calculate(damage, stats, damageType);

			if(CompareTag("Player"))
			{
				StatisticManager.Instance["Damage Recieved"].Value += damage;
			}
			else
			{
				StatisticManager.Instance["Damage Dealt"].Value += damage;
				
				switch(damageType)
				{
					case DamageType.Physical:
						StatisticManager.Instance["Physical Damage Dealt"].Value += damage;
						break;
					case DamageType.Fire:
						StatisticManager.Instance["Fire Damage Dealt"].Value += damage;
						break;
					case DamageType.Ice:
						StatisticManager.Instance["Ice Damage Dealt"].Value += damage;
						break;
					case DamageType.Electric:
						StatisticManager.Instance["Electric Damage Dealt"].Value += damage;
						break;
					case DamageType.Poison:
						StatisticManager.Instance["Poison Damage Dealt"].Value += damage;
						break;
				}
			}

			ApplyDamage(damage, damageType);
			lastHitTime = Time.time;
		}

		public void TriggerImmunity()
		{
			lastHitTime = Time.time;
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

			if(newMax > health.Value.Max)
			{
				health.FilledChange(newMax);
			}
			else
			{
				health.UnfilledChange(newMax);
			}
		}
	}
}