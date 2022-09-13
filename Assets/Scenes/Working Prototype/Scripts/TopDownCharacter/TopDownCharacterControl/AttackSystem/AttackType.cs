using UnityEngine;

namespace SodaRocket.TopDownCharacterController.AttackSystem
{
	public abstract class AttackType
	{
		public abstract void Attack(Transform origin, LayerMask mask);
	}
}