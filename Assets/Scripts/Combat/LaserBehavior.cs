using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat
{
    public class LaserBehavior : AttackBehavior
    {
        protected override void HitBehavior(GameObject other)
        {
            lifetime = 0.1f;
			List<RaycastHit2D> hits = new();
			
			Physics2D.RaycastNonAlloc(transform.position, transform.right, hits.ToArray(), stats["Range"].Value);
            
			foreach(RaycastHit2D hit in hits)
			{
				Hit(hit.transform.gameObject);
			}
        }

        protected override void OnStatsSet()
        {
            throw new System.NotImplementedException();
        }
    }
}
