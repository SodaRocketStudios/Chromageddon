using UnityEngine;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = " New Chain Lightning Behavior", menuName = "Combat/Attack Behavior/Chain Lightning Behavior")]

    public class ChainLightningBehavior : AttackBehavior
    {
		[SerializeField] private float damage;

        private int bounces;

        public override void OnStart(Attack attack)
        {
            bounces = (int)attack.Stats["Chain Lightning Bounces"].Value;

			// Bounce to targets

			Bounce(attack);

			attack.Despawn();
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

			Vector2 hitPosition = attack.LastHitObject.position;
            Collider2D[] hits = Physics2D.OverlapCircleAll(hitPosition, attack.Stats["Range"].Value, attack.CollisionMask & ~(1 << LayerMask.NameToLayer("Walls")));

			foreach(Collider2D hit in hits)
			{
				if(hit.transform == attack.LastHitObject)
				{
					continue;
				}

				hit.GetComponent<HitHandler>()?.Hit(damage, DamageType.Electric);

				bounces--;

				Bounce(attack);
				return;
			}
        }
    }
}