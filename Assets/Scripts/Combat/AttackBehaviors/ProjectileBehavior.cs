using UnityEngine;
using SRS.Stats;
using System;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = " New Projectile Behavior", menuName = "Combat/Attack Behavior/Projectile Behavior")]
    public class ProjectileBehavior : AttackBehavior
    {
        [SerializeField] private float speed = 1;

        private int bounces;
        private int pierces;

        public override void OnStart(Attack attack)
        {
            bounces = (int)attack.Stats["Bounces"].Value;
            pierces = (int)attack.Stats["Pierces"].Value;
        }

        public override void OnUpdate(Attack attack)
        {
            attack.transform.Translate(attack.transform.right*speed*Time.deltaTime, Space.World);
        }

        public override void OnFixedUpdate(Attack attack)
        {
            CollisionTest(attack);
        }

        public override void OnEnd(Attack attack)
        {
            //
        }

        protected override void CollisionTest(Attack attack)
        {
            RaycastHit2D hit = Physics2D.Raycast(attack.transform.position + attack.spriteSize.x*attack.transform.right, attack.transform.right, speed*Time.deltaTime, attack.collisionMask);

            if(hit)
            {
                if(hit.transform.gameObject != attack.LastHitObject)
                {
                    OnHit(attack, hit);
                    attack.LastHitObject = hit.transform.gameObject;
                }
            }
        }

        protected override void OnHit(Attack attack, RaycastHit2D hit)
        {
            HitHandler hitHandler = hit.transform.GetComponent<HitHandler>();
            hitHandler.Hit(attack.Stats, attack.DamageType);

            if(TryBounce(attack, hit) || TryPierce())
            {
                return;
            }

            attack.Despawn();
        }

        public override float GetLifetime(Attack attack)
        {
            return attack.Stats["Range"].Value/speed;
        }

        private bool TryBounce(Attack attack, RaycastHit2D hit)
        {
            if(bounces > 0)
            {
                Bounce(attack, hit);
                bounces--;
                return true;
            }

            return false;
        }

        private void Bounce(Attack attack, RaycastHit2D hit)
        {
            // TODO -- reset lifetime timer.
            RaycastHit2D[] hits = Physics2D.CircleCastAll(hit.point, attack.Stats["Range"].Value, attack.transform.right, 0, attack.collisionMask);

            foreach(RaycastHit2D target in hits)
            {
                if(target == attack.LastHitObject)
                {
                    continue;
                }

                Vector2 targetDirection = target.centroid - hit.point;

                if(Vector2.Dot(targetDirection, hit.normal) >= 0)
                {
                    attack.transform.right = target.centroid - (Vector2)attack.transform.position;
                    return;
                }
            }

            attack.transform.right = Vector2.Reflect(attack.transform.right, hit.normal);
        }

        private bool TryPierce()
        {
            if(pierces > 0)
            {
                pierces--;
                return true;
            }
            return false;
        }
    }
}