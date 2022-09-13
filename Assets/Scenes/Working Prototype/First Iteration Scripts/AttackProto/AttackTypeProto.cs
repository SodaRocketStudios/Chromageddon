using UnityEngine;

namespace SodaRocket.AttackProto
{
	public abstract class AttackTypeProto
	{
		public abstract void Attack(Transform origin, LayerMask mask);
	}
}