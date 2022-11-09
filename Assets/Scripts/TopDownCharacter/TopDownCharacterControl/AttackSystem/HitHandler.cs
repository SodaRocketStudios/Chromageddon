using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;
using SRS.Health;
using SRS.StatusEffects;
using SRS.Extensions;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class HitHandler : MonoBehaviour
	{
		public delegate void OnHitHandler(Dictionary<string, Stat> attackStats);
		public event OnHitHandler OnHitEvent;

		// TODO Determine a better way to populate the list of status effects
		[SerializeField] private List<StatusEffect> effects;

		private HealthManager health;

		private System.Random random = new System.Random();

		private void Awake()
		{
			health = GetComponent<HealthManager>();
		}

		public void HandleHit(Dictionary<string, Stat> attackStats)
		{
			OnHitEvent?.Invoke(attackStats);

			health.Damage(attackStats["Damage"].Value);

			foreach(StatusEffect effect in effects)
			{
				if(random.NextFloat() <= attackStats[effect.ProcStat].Value)
				{
					effect.Apply(gameObject);
				}
			}
		}
	}
}