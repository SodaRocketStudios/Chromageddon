using UnityEngine;
using System.Collections.Generic;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class AttackType : ScriptableObject
	{
		protected Dictionary<string, Stat> attackStats;

		public virtual void Attack(Transform origin, float attackAngle, LayerMask mask){}

		public void UpdateStats(Dictionary<string, Stat> stats)
		{
			attackStats = new Dictionary<string, Stat>(stats);
		}
	}
}