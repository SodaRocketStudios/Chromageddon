using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SRS.Combat
{
    public class LaserBehavior : AttackBehavior
    {

        protected override void OnStatsSet()
        {
			lifetime = 0.1f;
			List<RaycastHit2D> hits;
			
			hits = Physics2D.RaycastAll(transform.position, transform.right, stats["Range"].Value).ToList();
            
			foreach(RaycastHit2D hit in hits)
			{
				Hit(hit.transform.gameObject);
			}
        }
		
        protected override void HitBehavior(GameObject other)
        {
        }

    }
}
