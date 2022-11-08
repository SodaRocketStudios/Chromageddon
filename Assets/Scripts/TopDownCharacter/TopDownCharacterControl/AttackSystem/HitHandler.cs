using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;
using SRS.Health;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class HitHandler : MonoBehaviour
	{
		public delegate void OnHitHandler(Dictionary<string, Stat> attackStats);
		public event OnHitHandler OnHitEvent;

		private HealthManager health;

		private void Awake()
		{
			health = GetComponent<HealthManager>();
		}

		public void HandleHit(Dictionary<string, Stat> attackStats)
		{
			OnHitEvent?.Invoke(attackStats);

			health.Damage(attackStats["Damage"].Value);

			// TODO Try to apply status effects.
		}
	}
}