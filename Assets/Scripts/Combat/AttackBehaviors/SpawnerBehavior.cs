using UnityEngine;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = "New Spawner Behavior", menuName = "Combat/Attack Behavior/Spawner Behavior")]
    public class SpawnerBehavior : AttackBehavior
    {
        public override float GetLifetime(Attack attack)
        {
			return 0;
        }

        public override void OnEnd(Attack attack)
        {
        }

        public override void OnFixedUpdate(Attack attack)
        {
        }

        public override void OnStart(Attack attack)
        {
			// TODO -- spawn mini followers
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