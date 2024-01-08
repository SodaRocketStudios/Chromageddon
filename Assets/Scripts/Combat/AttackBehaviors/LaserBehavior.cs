using UnityEngine;

namespace SRS.Combat
{
    public class LaserBehavior : AttackBehavior
    {
        [SerializeField] private float chargeTime;

        public override void OnStart(Attack attack)
        {
            // TODO -- Implement a charge time for the laser
            CollisionTest(attack);
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
            RaycastHit2D[] hits = Physics2D.RaycastAll(attack.transform.position, attack.transform.right, attack.Stats["Range"].Value);

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
            // TODO -- determine lifetime based on animation
            return 1;
        }
    }
}
