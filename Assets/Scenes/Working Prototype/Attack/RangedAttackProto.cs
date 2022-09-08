using UnityEngine;

namespace SodaRocket.AttackProto
{
	public class RangedAttackProto : AttackTypeProto
	{
        public override void Attack(Transform origin, LayerMask mask)
        {
			// fire a projectile with a random angle determine by spread
			// also need to add in the player's speed.
			Debug.Log("Attack with a ranged attack.");
        }
    }
}