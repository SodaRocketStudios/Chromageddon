using System.Collections.Generic;
using System.Linq;
using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
    public class LaserBehavior : AttackBehavior
    {
        [SerializeField] private float chargeTime;

        public override void OnStart(Attack attack)
        {
            CollisionTest(attack); // By calling this in OnEnd i could allow for a charge time.
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
            List<RaycastHit2D> hits = Physics2D.RaycastAll(attack.transform.position, attack.transform.right, attack.Stats["Range"].Value).ToList();

            foreach(var hit in hits)
            {
                OnHit(attack, hit.transform.gameObject);
            }
        }

        protected override void OnHit(Attack attack, GameObject other)
        {
            HitHandler hitHandler;

            if(other.TryGetComponent(out hitHandler))
            {
                hitHandler.Hit(attack.Stats, attack.DamageType);
            }
        }

        public override float GetLifetime(Attack attack)
        {
            throw new System.NotImplementedException();
        }
    }
}
