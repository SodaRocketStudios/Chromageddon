using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = " New Projectile Behavior", menuName = "Combat/Attack Behavior/Projectile Behavior")]
    public class ProjectileBehavior : AttackBehavior
    {
        [SerializeField] private float speed = 1;

        public override void OnEnd(Attack attack)
        {
            throw new NotImplementedException();
        }

        public override void OnFixedUpdate(Attack attack)
        {
            throw new NotImplementedException();
        }

        public override void OnStart(Attack attack)
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate(Attack attack)
        {
            throw new NotImplementedException();
        }

        protected override void CollisionTest(Attack attack)
        {
            throw new NotImplementedException();
        }

        protected override void OnHit(Attack attack, GameObject other)
        {
            throw new NotImplementedException();
        }
    }
}