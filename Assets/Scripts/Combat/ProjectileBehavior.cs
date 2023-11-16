using System.Collections.Generic;
using UnityEngine;
using SRS.Extensions.Random;
using System;

namespace SRS.Combat
{
    public class ProjectileBehavior : AttackBehavior
    {
        [SerializeField] private float speed = 1;

        private int RemainingBounces;
        private int RemainingPierces;

        private System.Random random = new(Guid.NewGuid().GetHashCode());

        private void Update()
        {
            transform.Translate(transform.right*speed*Time.deltaTime, Space.World);
        }

        protected override void OnStatsSet()
        {
			lifetime = stats["Range"].Value/speed;
            RemainingBounces = (int)stats["Bounces"].Value;
            RemainingPierces = (int)stats["Pierces"].Value;
        }

        protected override void HitBehavior(GameObject other)
        {
            while(RemainingBounces > 0)
            {
                ResetLiftime();
                Vector2 targetDirection = FindBounceTarget(other) - (Vector2)transform.position;
                // Vector2.SignedAngle(transform.right, targetDirection);
                transform.right = targetDirection;
                RemainingBounces--;
                return;
            }

            while(RemainingPierces > 0)
            {
                ResetLiftime();
                RemainingPierces--;
                return;
            }
        }

        private Vector2 FindBounceTarget(GameObject other)
        {
            LayerMask mask = LayerMask.GetMask(LayerMask.LayerToName(other.layer));
            mask.value |= LayerMask.GetMask("Environment");
            
            List<RaycastHit2D> hits = new();
            Physics2D.CircleCastNonAlloc(transform.position, stats["Range"].Value, transform.right, hits.ToArray(), 0, mask);

            foreach(RaycastHit2D hit in hits)
            {
                if(hit.transform == other.transform)
                {
                    continue;
                }

                return other.transform.position;
            }

            return (Vector2)transform.position + random.WithinUnitCircle();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Hit(other.gameObject);
        }
    }
}