using UnityEngine;

namespace SRS.AttackProto
{
	public abstract class AttackTypeProto
	{
		public abstract void Attack(Transform origin, LayerMask mask);
	}
}