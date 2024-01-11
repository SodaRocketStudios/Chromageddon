using UnityEngine;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = "New Laser Behavior", menuName = "Combat/Attack Behavior/Laser Behavior")]
    public class LaserBehavior : AttackBehavior
    {
        [SerializeField] private float chargeTime;

        private float timer;

        public override void OnStart(Attack attack)
        {
            // TODO -- Stop multiple laser from charging at once if fire rate is too fast.
            // maybe fire rate should be used to determine the charge time.
            timer = 0;
            
            CollisionTest(attack);
        }

        public override void OnUpdate(Attack attack)
        {
            if(timer >= chargeTime)
            {
                // TODO -- play firing animation.
                CollisionTest(attack);
            }
            // TODO -- play charge animation.
            timer += Time.deltaTime;
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
            // TODO -- set a better lifetime.
            return chargeTime*2;
        }
    }
}
