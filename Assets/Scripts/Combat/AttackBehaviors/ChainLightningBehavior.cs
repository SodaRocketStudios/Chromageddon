using UnityEngine;

namespace SRS.Combat
{
    public class ChainLightningBehavior : AttackBehavior
    {
        public override float GetLifetime(Attack attack)
        {
            return 1;
        }

        public override void OnEnd(Attack attack)
        {
        }

        public override void OnFixedUpdate(Attack attack)
        {
        }

        public override void OnStart(Attack attack)
        {
        }

        public override void OnUpdate(Attack attack)
        {
        }

        protected override void CollisionTest(Attack attack)
        {
        }

        protected override void OnHit(Attack attack, RaycastHit2D hit)
        {
        }
    }
}