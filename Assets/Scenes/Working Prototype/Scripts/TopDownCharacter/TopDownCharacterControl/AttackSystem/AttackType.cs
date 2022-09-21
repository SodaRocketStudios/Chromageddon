using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.TopDownCharacterController.AttackSystem
{
	public abstract class AttackType
	{
		protected Dictionary<string, Stat> attackStats;

		public abstract void Attack(Transform origin, LayerMask mask);

		public void UpdateStats(Dictionary<string, Stat> stats)
		{
			attackStats = stats;
		}
	}
}