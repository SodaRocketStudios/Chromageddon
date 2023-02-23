using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;
using SRS.Health;
using SRS.StatusEffects;
using SRS.Extensions.Random;
using UnityEngine.Events;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class HitHandler : MonoBehaviour
	{
		public delegate void OnHitHandler(Dictionary<string, Stat> attackStats);
		public UnityEvent OnHitEvent;

		private HealthManager healthManager;
		private StatusEffectTracker effectTracker;

		private System.Random random = new System.Random();

		private void Awake()
		{
			healthManager = GetComponent<HealthManager>();
			effectTracker = GetComponent<StatusEffectTracker>();
		}

		public void HandleHit(CharacterStats characterStats)
		{
			float Damage = characterStats["Damage"];

			OnHitEvent?.Invoke();

			// foreach(StatusEffect effect in StatusEffectDatabase.Instance.StatusEffects())
			// {
			// 	if(random.NextFloat() <= attackStats[effect.ProcStat].Value)
			// 	{
			// 		effect.Apply(gameObject);
			// 	}
			// }

			healthManager.Damage(Damage);
		}
	}
}