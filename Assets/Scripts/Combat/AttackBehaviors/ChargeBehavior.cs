using UnityEngine;
using SRS.PawnController;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = "New Charge Behavior", menuName = "Combat/Attack Behavior/Charge Behavior")]
    public class ChargeBehavior : AttackBehavior
    {
        [SerializeField] private float delay;

        [SerializeField] private float chargeSpeed;

        public override float GetLifetime(Attack attack)
        {
            return attack.Stats["Attack Delay"].Value;
        }

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
            if(attack.Timer > delay)
            {
                attack.Attacker.GetComponent<PawnMover>().AddVelocity(attack.Attacker.transform.right*chargeSpeed);
                attack.Despawn();
            }
        }

        protected override void CollisionTest(Attack attack)
        {
        }

        protected override void OnHit(Attack attack, RaycastHit2D hit)
        {
        }
    }
}