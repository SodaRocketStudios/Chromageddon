using UnityEngine;

namespace SRS.TopDownCharacterController.AttackSystem
{
	public abstract class AttackType
	{
		public abstract void Attack(Transform origin, LayerMask mask);
	}
}