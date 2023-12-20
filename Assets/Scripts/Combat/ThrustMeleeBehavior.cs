using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SRS.Combat
{
    public class ThrustMeleeBehavior : AttackBehavior
    {
		[SerializeField] private float attackWidth;

        public override void FixedUpdate(Transform transform)
        {
            throw new System.NotImplementedException();
        }

        public override void OnDestroy()
        {
            throw new System.NotImplementedException();
        }

        public override void Start()
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Transform transform)
        {
            throw new System.NotImplementedException();
        }

        protected override void HitCast(Transform transform)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnHitBehavior(GameObject other)
        {
            throw new System.NotImplementedException();
        }

        // protected override void OnStatsSet()
        // {
        //     lifetime = 0.1f;
        // 	List<RaycastHit2D> hits;

        // 	hits = Physics2D.BoxCastAll(transform.position, new Vector2(attackWidth, 0.1f), 0, transform.right, stats["Range"].Value).ToList();

        // 	foreach(RaycastHit2D hit in hits)
        // 	{
        // 		Hit(hit.transform.gameObject);
        // 	}
        // }

        // protected override void HitBehavior(GameObject other)
        // {
        // }
    }
}