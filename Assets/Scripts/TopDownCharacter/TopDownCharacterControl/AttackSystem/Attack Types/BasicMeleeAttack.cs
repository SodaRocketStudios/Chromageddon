using UnityEngine;

namespace SRS.TopDownCharacterControl.AttackSystem
{
    [CreateAssetMenu(fileName = "Basic Melee Attack", menuName = "Attacks/Basic Melee Attack")]
	public class BasicMeleeAttack : AttackType
	{
        public override void Attack(Transform origin, float attackAngle, LayerMask mask)
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(origin.position, characterStats["Range"], origin.forward, 0, mask);

            foreach(RaycastHit2D hit in hits)
            {
                float hitAngle = Vector2.Angle(origin.right, hit.transform.position - origin.position);
                
                if(hitAngle <= attackAngle/2)
                {
                    HitHandler hitHandler;
                    if(hit.transform.TryGetComponent<HitHandler>(out hitHandler))
                    {
                        hitHandler.HandleHit(characterStats);
                    }
                }
            }
        }
	}
}