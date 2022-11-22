using UnityEngine;
using System.Collections.Generic;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class AttackType : ScriptableObject
	{
		public bool attackActive {get; protected set;}

		protected Dictionary<string, Stat> attackStats = new Dictionary<string, Stat>();

		public virtual void Attack(Transform origin, float attackAngle, LayerMask mask){}

		public void UpdateStats(Dictionary<string, Stat> stats)
		{
			attackStats = new Dictionary<string, Stat>(stats);
		}
	}
}