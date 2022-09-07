using UnityEngine;

namespace SodaRocket.AttackProto
{
	public class MeleeAttackProto : AttackTypeProto
	{
        public override void Attack()
        {
			// Find all enemies within range, then narrow it down to the enemies that are within the attack arc.
			Debug.Log("Attack with a melee attack");
        }
    }
}