using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public abstract class AttackType
	{
		protected Dictionary<string, Stat> attackStats;

		public abstract void Attack(Transform origin, float attackAngle, LayerMask mask);

		public void UpdateStats(Dictionary<string, Stat> stats)
		{
			attackStats = new Dictionary<string, Stat>(stats);
		}
	}
}