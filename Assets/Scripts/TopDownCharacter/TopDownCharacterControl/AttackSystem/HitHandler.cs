using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SRS.StatSystem;
using SRS.Health;
using SRS.StatusEffects;
using SRS.Extensions.Random;

namespace SRS.TopDownCharacterControl.AttackSystem
{

	public class HitHandler : MonoBehaviour
	{
		public delegate void OnHitHandler(Dictionary<string, Stat> attackStats);
		public UnityEvent OnHitEvent;

		private HealthManager healthManager;
		private StatusEffectTracker effectTracker;
		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

		private void Awake()
		{
			healthManager = GetComponent<HealthManager>();
			effectTracker = GetComponent<StatusEffectTracker>();
		}

		public void HandleHit(CharacterStats characterStats)
		{
			float Damage = characterStats["Damage"];

			Damage *= random.NextFloat() <= characterStats["Critical Chance"] ? characterStats["Critical Damage"] : 1;

			healthManager.Damage(Damage);

			if(healthManager.CurrentHealth <= 0) return;

			OnHitEvent?.Invoke();

			// foreach(StatusEffect effect in StatusEffectDatabase.Instance.StatusEffects())
			// {
			// 	if(random.NextFloat() <= attackStats[effect.ProcStat].Value)
			// 	{
			// 		effect.Apply(gameObject);
			// 	}
			// }

		}
	}
}