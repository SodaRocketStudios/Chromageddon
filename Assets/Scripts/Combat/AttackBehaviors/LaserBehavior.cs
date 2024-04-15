using System;
using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = "New Laser Behavior", menuName = "Combat/Attack Behavior/Laser Behavior")]
    public class LaserBehavior : AttackBehavior
    {
        [SerializeField] private float chargeTime;
        [SerializeField] private bool overrideChargeTime;

        private Vector2 size;

        private System.Random random = new(Guid.NewGuid().GetHashCode());

        public override void OnStart(Attack attack)
        {
            if(overrideChargeTime == false)
            {
                chargeTime = attack.Stats["Attack Delay"].Value/2;
            }

            float spreadAngle = attack.Stats["Max Spread"].Value * (1 - attack.Stats["Accuracy"].Value)/2;
            Vector3 rotation = new(0, 0, random.NextFloat(-spreadAngle, spreadAngle));
            attack.transform.Rotate(rotation);

            size = attack.spriteSize;
            size.x = attack.Stats["Range"].Value;
        }

        public override void OnUpdate(Attack attack)
        {
            attack.SpriteRenderer.size = size;

            if(attack.Flag)
            {
                return;
            }

            if(attack.Timer >= chargeTime)
            {
                CollisionTest(attack);
                attack.PlayAnimation("Laser");
                attack.Flag = true;
            }
        }

        public override void OnFixedUpdate(Attack attack)
        {
        }

        public override void OnEnd(Attack attack)
        {
        }

        protected override void CollisionTest(Attack attack)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(attack.transform.position, attack.transform.right, attack.Stats["Range"].Value, attack.CollisionMask);

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
            return Mathf.Max(chargeTime*1.5f, 1);
        }
    }
}
