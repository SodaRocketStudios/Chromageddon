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

		private List<EffectTimer> effectsToRemove = new();

		private static System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

		private void Awake()
		{
			hitHandler = GetComponent<HitHandler>();
		}

		private void OnEnable()
		{
			hitHandler.TryHitEffects += TryOnHitEffects;
			RemoveAllEffects();
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

				if(timer.IsComplete)
				{
					RemoveEffect(timer);
				}
			}

			foreach(EffectTimer effect in effectsToRemove)
			{
				activeEffectTimers.Remove(effect);
			}

			effectsToRemove.Clear();
		}

		public void AddEffect(LastingEffect effect)
		{
			EffectTimer timer = new(effect, gameObject);
			activeEffectTimers.Add(timer);
		}

		public void RemoveEffect(EffectTimer effect)
		{
			if(effectsToRemove.Contains(effect))
			{
				return;
			}
			
			effect.RemoveEffect(gameObject);
			effectsToRemove.Add(effect);
		}

		public void RemoveAllEffects()
		{
			foreach(EffectTimer effect in activeEffectTimers)
			{
				RemoveEffect(effect);
			}
		}

		public void TryOnHitEffects(StatContainer attackerStats)
		{
			foreach(HitEffect effect in effectDatabase.Effects)
			{
				float randomNumber = random.NextFloat();

				if(randomNumber <= effect.GetProcChance(attackerStats))
				{
					effect.Trigger(gameObject);
				}
			}
		}
	}
}