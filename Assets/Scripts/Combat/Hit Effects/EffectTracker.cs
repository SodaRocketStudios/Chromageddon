using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;

namespace SRS.Combat.HitEffects
{
	public class EffectTracker : MonoBehaviour
	{
		[SerializeField] private HitEffectDatabase effectDatabase;

		private HitHandler hitHandler;

		private List<EffectTimer> activeEffectTimers = new();

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
			EffectTimer timer = new(effect);
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
				// try to apply the effect based on attacker stats.
			}
		}
	}
}