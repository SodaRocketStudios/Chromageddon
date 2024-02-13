using System;
using UnityEngine;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = "New Laser Behavior", menuName = "Combat/Attack Behavior/Laser Behavior")]
    public class LaserBehavior : AttackBehavior
    {
        private Vector2 startPosition;

        private Vector2 direction;

        private float chargeTime;

        private float timer;

        private bool hasFired;

        public override void OnStart(Attack attack)
        {
            timer = 0;

            chargeTime = attack.Stats["Attack Delay"].Value/2;
            
            startPosition = attack.transform.position;
            direction = attack.transform.right;

            hasFired = false;
        }

        public override void OnUpdate(Attack attack)
        {
            Debug.DrawRay(startPosition, direction*attack.Stats["Range"].Value);

            if(hasFired)
            {
                Debug.DrawRay(startPosition, direction*attack.Stats["Range"].Value, Color.red);
                return;
            }

            if(timer >= chargeTime)
            {
                // TODO -- play firing animation.
                CollisionTest(attack);
                hasFired = true;
            }
            // TODO -- play charge animation.
            timer += Time.deltaTime;
        }

        public override void OnFixedUpdate(Attack attack)
        {
        }

        public override void OnEnd(Attack attack)
        {
        }

        protected override void CollisionTest(Attack attack)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(attack.transform.position, direction, attack.Stats["Range"].Value, attack.CollisionMask);

            foreach(var hit in hits)
            {
                Hit(attack, hit);
            }
        }

        protected override void OnHit(Attack attack, RaycastHit2D hit)
        {
        }

        public override float GetLifetime(Attack attack)
        {
            // TODO -- set a better lifetime.
            return chargeTime*1.5f;
        }
    }
}
