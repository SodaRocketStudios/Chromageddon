using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;
using SRS.Health;
using SRS.StatusEffects;
using SRS.Extensions;
using UnityEngine.Events;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class HitHandler : MonoBehaviour
	{
		public delegate void OnHitHandler(Dictionary<string, Stat> attackStats);
		public UnityEvent OnHitEvent;

		private HealthManager health;

		private System.Random random = new System.Random();

		private void Awake()
		{
			health = GetComponent<HealthManager>();
		}

		public void HandleHit(Dictionary<string, Stat> attackStats)
		{
			OnHitEvent?.Invoke();

			foreach(StatusEffect effect in StatusEffectDatabase.Instance.StatusEffects())
			{
				if(random.NextFloat() <= attackStats[effect.ProcStat].Value)
				{
					effect.Apply(gameObject);
				}
			}

			health.Damage(attackStats["Damage"].Value);
		}
	}
}