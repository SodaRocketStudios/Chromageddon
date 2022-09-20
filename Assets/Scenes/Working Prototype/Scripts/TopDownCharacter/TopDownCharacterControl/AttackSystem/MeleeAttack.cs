using UnityEngine;

namespace SRS.TopDownCharacterController.AttackSystem
{
	public class MeleeAttack : AttackType
	{
		public float Range{get; set;}
		public float ArcAngle{get; set;}
		
		public MeleeAttack(float _range, float _arcAngle)
		{
			Range = _range;
			ArcAngle = _arcAngle;
		}

        public override void Attack(Transform origin, LayerMask mask)
        {
			// Need to find all enemies within an attack zone.
            RaycastHit2D[] hits = Physics2D.CircleCastAll(origin.position, Range, origin.forward, 0, mask);

            foreach(RaycastHit2D hit in hits)
            {
                float hitAngle = Vector2.Angle(origin.right, hit.transform.position - origin.position);
                
                if(hitAngle <= ArcAngle/2)
                {
                    // TO DO -- Implement damage
                }
            }
        }
	}
}