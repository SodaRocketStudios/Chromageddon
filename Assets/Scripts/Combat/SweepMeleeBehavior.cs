using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat
{
    public class SweepMeleeBehavior : AttackBehavior
    {
        [SerializeField] private float sweepAngle;

        protected override void OnStatsSet()
        {
			lifetime = 0.1f;
			List<RaycastHit2D> hits = new();
			Physics2D.CircleCastNonAlloc(transform.position, stats["range"].Value, transform.right, hits.ToArray());
            
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
