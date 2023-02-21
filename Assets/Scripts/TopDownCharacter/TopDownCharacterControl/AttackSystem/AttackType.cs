using UnityEngine;
using System.Collections.Generic;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class AttackType : ScriptableObject
	{
		public bool attackActive {get; protected set;}

		protected CharacterStats characterStats;

		public virtual void Attack(Transform origin, float attackAngle, LayerMask mask){}
	}
}