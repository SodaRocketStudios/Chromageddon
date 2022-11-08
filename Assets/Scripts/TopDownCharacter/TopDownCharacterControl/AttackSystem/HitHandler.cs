using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class HitHandler : MonoBehaviour
	{
		public delegate void OnHitHandler(Dictionary<string, Stat> attackStats);
		public event OnHitHandler OnHitEvent;

		public void HandleHit(Dictionary<string, Stat> attackStats)
		{
			OnHitEvent?.Invoke(attackStats);
		}
	}
}