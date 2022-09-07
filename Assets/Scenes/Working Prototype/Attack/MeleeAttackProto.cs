using UnityEngine;

namespace SodaRocket.AttackProto
{
	public class MeleeAttackProto : AttackTypeProto
	{
        public override void Attack(Transform origin)
        {
			// Need to find all enemies within an attack zone.
            RaycastHit2D hit = Physics2D.BoxCast(origin.position, Vector2.one*20, 0, origin.right, 20, LayerMask.NameToLayer("Enemy"));

            Debug.DrawLine(origin.position, origin.position + origin.right*20, Color.white, 1);

            Debug.Log(hit.collider);

            if(hit.collider != null)
            {
                Debug.Log("Hit Enemy");
            }
        }
    }
}