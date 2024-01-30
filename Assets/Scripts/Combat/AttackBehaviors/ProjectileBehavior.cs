using System;
using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = " New Projectile Behavior", menuName = "Combat/Attack Behavior/Projectile Behavior")]
    public class ProjectileBehavior : AttackBehavior
    {
        [SerializeField] private float speed = 1;

        private System.Random random = new(Guid.NewGuid().GetHashCode());

        private int bounces;
        private int pierces;

        public override void OnStart(Attack attack)
        {
            bounces = (int)attack.Stats["Bounces"].Value;
            pierces = (int)attack.Stats["Pierces"].Value;
            float spreadAngle = attack.Stats["Spread"].Value/2;
            Vector3 rotation = new(0, 0, random.NextFloat(-spreadAngle, spreadAngle));
            attack.transform.Rotate(rotation);
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
            RaycastHit2D hit = Physics2D.Raycast(attack.transform.position + attack.spriteSize.x*attack.transform.right, attack.transform.right, speed*Time.deltaTime, attack.CollisionMask);

            if(hit)
            {
                if(hit.transform.gameObject != attack.LastHitObject)
                {
                    Hit(attack, hit);
                }
            }
        }

        protected override void OnHit(Attack attack, RaycastHit2D hit)
        {
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
            RaycastHit2D[] hits = Physics2D.CircleCastAll(hit.point, attack.Stats["Range"].Value, attack.transform.right, 0, attack.CollisionMask & ~(1 << LayerMask.NameToLayer("Walls")));

            attack.ResetLifetime();

            foreach(RaycastHit2D target in hits)
            {
                if(target.transform == attack.LastHitObject)
                {
                    continue;
                }

                Vector2 targetDirection = (Vector2)target.transform.position - hit.point;

                if(Vector2.Angle(targetDirection, hit.normal) <= 90)
                {
                    attack.transform.right = target.transform.position - attack.transform.position;
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