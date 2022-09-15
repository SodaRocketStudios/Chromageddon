using UnityEngine;
using SRS.HealthProto;
using UnityEditor;

namespace SRS.AttackProto
{
	public class MeleeAttackProto : AttackTypeProto
	{
        private float arcAngle = 30;

        public override void Attack(Transform origin, LayerMask mask)
        {
			// Need to find all enemies within an attack zone.
            RaycastHit2D hit = Physics2D.CircleCast(origin.position, 10, origin.forward, 0, mask);

            Debug.Log(hit.collider);

            if(hit.collider != null)
            {
                float hitAngle = Vector2.Angle(origin.right, hit.transform.position - origin.position);
                
                if(hitAngle <= arcAngle)
                {
                    HealthManagerProto health = hit.transform.gameObject.GetComponent<HealthManagerProto>();
                    health.Damage(10);
                }
            }
        }
    }
}