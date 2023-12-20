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

        private System.Random random = new(Guid.NewGuid().GetHashCode());

        public override void Update(Transform transform)
        {
            transform.Translate(transform.right*speed*Time.deltaTime, Space.World);
        }

        protected override void HitCast(Transform transform)
        {

        }
        
        protected override void OnHitBehavior(GameObject other)
        {

        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void FixedUpdate(Transform transform)
        {
            throw new NotImplementedException();
        }

        public override void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}