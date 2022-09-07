using UnityEngine;

namespace SodaRocket.AttackProto
{
	public class MeleeAttackProto : AttackTypeProto
	{
        public override void Attack()
        {
			Debug.Log("Attack with a melee attack");
        }
    }
}