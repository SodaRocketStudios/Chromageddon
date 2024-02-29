using UnityEngine;
using SRS.Utils.ObjectPooling;
using SRS.Utils.VFX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = " New Chain Lightning Behavior", menuName = "Combat/Attack Behavior/Chain Lightning Behavior")]

    public class ChainLightningBehavior : AttackBehavior
    {
		[SerializeField] private float damage;

		[SerializeField] private float bounceDistance;

        [SerializeField] private ObjectPool lightningPool;

        [SerializeField] private float VFXLifetime;

        private System.Random random = new(Guid.NewGuid().GetHashCode());

        private int bounces;

        public override void OnStart(Attack attack)
        {
            bounces = (int)attack.Stats["Chain Lightning Bounces"].Value;

			Bounce(attack);
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
        }

        protected override void OnHit(Attack attack, RaycastHit2D hit)
        {
        }

        public override float GetLifetime(Attack attack)
        {
            return 1;
        }

        private void Bounce(Attack attack)
        {
			if(bounces <= 0)
			{
				attack.Despawn();
				return;
			}

			Vector2 startPosition;

			if(attack.LastHitObject == null)
			{
				startPosition = attack.transform.position;
			}
			else
			{
				startPosition = attack.LastHitObject.position;
			}

            List<Collider2D> hits = Physics2D.OverlapCircleAll(startPosition, bounceDistance, attack.CollisionMask & ~(1 << LayerMask.NameToLayer("Walls"))).ToList();

            int removeIndex = -1;

            foreach(Collider2D hit in hits)
            {
                if(hit.transform == attack.LastHitObject)
                {
                    removeIndex = hits.IndexOf(hit);
                }
            }

            if(removeIndex >= 0)
            {   
                hits.RemoveAt(removeIndex);
            }

            if(hits.Count <= 0)
            {
                return;
            }

            Collider2D target = hits[random.Next(0, hits.Count)];

            LineDrawer lightningFX = lightningPool.Get() as LineDrawer;

            lightningFX.Initialize(startPosition, target.transform.position, VFXLifetime);

            target.GetComponent<HitHandler>()?.Hit(damage, DamageType.Electric);

            attack.LastHitObject = target.transform;

            bounces--;

            Bounce(attack);
            return;
        }
    }
}