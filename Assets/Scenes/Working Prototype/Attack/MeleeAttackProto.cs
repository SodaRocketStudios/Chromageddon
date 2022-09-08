using UnityEngine;
using SodaRocket.HealthProto;

namespace SodaRocket.AttackProto
{
	public class MeleeAttackProto : AttackTypeProto
	{
        public override void Attack(Transform origin, LayerMask mask)
        {
			// Need to find all enemies within an attack zone.
            RaycastHit2D hit = Physics2D.BoxCast(origin.position + origin.right, Vector2.one, 10, origin.right, 0, mask);

            Debug.Log(hit.collider);

            if(hit.collider != null)
            {
                HealthManagerProto health = hit.transform.gameObject.GetComponent<HealthManagerProto>();
                health.Damage(10);
                Debug.Log($" dealt {10} damage reducing current health to {health.CurrentHealth}.");
            }
        }
    }
}