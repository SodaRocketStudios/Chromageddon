using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat
{
    public class ThrustMeleeBehavior : AttackBehavior
    {
		[SerializeField] private float attackWidth;

        protected override void OnStatsSet()
        {
            lifetime = 0.1f;
			List<RaycastHit2D> hits = new();
			
			Physics2D.BoxCastNonAlloc(transform.position, new Vector2(attackWidth, 0.1f), 0, transform.right, hits.ToArray(), stats["Range"].Value);
            
			foreach(RaycastHit2D hit in hits)
			{
				Hit(hit.transform.gameObject);
			}
        }

        protected override void HitBehavior(GameObject other)
        {
            throw new System.NotImplementedException();
        }
    }
}