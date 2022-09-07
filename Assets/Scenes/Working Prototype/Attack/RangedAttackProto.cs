using UnityEngine;

namespace SodaRocket.AttackProto
{
	public class RangedAttackProto : AttackTypeProto
	{
        public override void Attack()
        {
			Debug.Log("Attack with a ranged attack.");
        }
    }
}