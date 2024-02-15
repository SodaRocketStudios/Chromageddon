using System.Collections.Generic;
using System.Linq;
using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
    public class ThrustMeleeBehavior : AttackBehavior
    {
		[SerializeField] private float attackWidth;

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

        public override float GetLifetime(Attack attack)
        {
            // TODO -- Setermine lifetime based on animations
            return 1;
        }
    }
}