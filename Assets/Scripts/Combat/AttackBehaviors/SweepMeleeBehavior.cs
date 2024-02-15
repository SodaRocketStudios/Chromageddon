using UnityEngine;

namespace SRS.Combat
{
    public class SweepMeleeBehavior : AttackBehavior
    {
        [SerializeField] private float sweepAngle;

        public override void OnStart(Attack attack)
        {
        }

        public override void OnUpdate(Attack attack)
        {
        }

        public override void OnFixedUpdate(Attack attack)
        {
        }

        public override void OnEnd(Attack attack)
        {
        }

        protected override void CollisionTest(Attack attack)
        {
            //TODO -- get all eneies within attack arc.
        }

        protected override void OnHit(Attack attack, RaycastHit2D hit)
        {
        }

        public override float GetLifetime(Attack attack)
        {
            // TODO -- Determine lifetime based on animations
            return 1;
        }
    }
}
