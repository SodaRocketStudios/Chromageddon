using System;
using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;
using SRS.Extensions.Random;

namespace SRS.Combat.HitEffects
{
	public class EffectTracker : MonoBehaviour
	{
		[SerializeField] private HitEffectDatabase effectDatabase;

		private HitHandler hitHandler;

		private List<EffectTimer> activeEffectTimers = new();

		private static System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

		private void Awake()
		{
			hitHandler = GetComponent<HitHandler>();
		}

		private void OnEnable()
		{
			hitHandler.TryHitEffects += TryOnHitEffects;
		}

		private void OnDisable()
		{
			hitHandler.TryHitEffects -= TryOnHitEffects;
		}

		private void Update()
		{
			foreach(EffectTimer timer in activeEffectTimers)
			{
				timer.Update(Time.deltaTime);
			}
		}

		public void AddEffect(LastingEffect effect)
		{
			EffectTimer timer = new(effect, gameObject);
			timer.OnTimerEnd += RemoveEffect;
			activeEffectTimers.Add(timer);
		}

		public void RemoveEffect(EffectTimer timer)
		{
			timer.RemoveEffect(gameObject);
			activeEffectTimers.Remove(timer);
		}

		public void TryOnHitEffects(StatContainer attackerStats)
		{
			foreach(HitEffect effect in effectDatabase.Effects)
			{
				// TODO -- could I use the same random number for all effects?
				float randomNumber = random.NextFloat();

				if(randomNumber <= effect.GetProcChance(attackerStats))
				{
					effect.Trigger(gameObject);
				}
			}
		}
	}
}