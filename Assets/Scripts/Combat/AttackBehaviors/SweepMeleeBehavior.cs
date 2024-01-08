using System.Collections.Generic;
using System.Linq;
using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
    public class SweepMeleeBehavior : AttackBehavior
    {
        [SerializeField] private float sweepAngle;

        public override void OnEnd(Attack attack)
        {
            throw new System.NotImplementedException();
        }

        public override void OnFixedUpdate(Attack attack)
        {
            throw new System.NotImplementedException();
        }

        public override void OnStart(Attack attack)
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate(Attack attack)
        {
            throw new System.NotImplementedException();
        }

        protected override void CollisionTest(Attack attack)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnHit(Attack attack, GameObject other)
        {
            throw new System.NotImplementedException();
        }

        public override float GetLifetime(Attack attack)
        {
            // TODO -- Setermine lifetime based on animations
            return 1;
        }
    }
}
