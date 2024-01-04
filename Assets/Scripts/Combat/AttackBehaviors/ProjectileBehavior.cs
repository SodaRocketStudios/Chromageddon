using UnityEngine;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = " New Projectile Behavior", menuName = "Combat/Attack Behavior/Projectile Behavior")]
    public class ProjectileBehavior : AttackBehavior
    {
        [SerializeField] private float speed = 1;

        public override void OnStart(Attack attack)
        {
            // 
        }

        public override void OnUpdate(Attack attack)
        {
            attack.transform.Translate(attack.transform.right*speed*Time.deltaTime, Space.World);
        }

        public override void OnFixedUpdate(Attack attack)
        {
            CollisionTest(attack);
        }

        public override void OnEnd(Attack attack)
        {
            //
        }

        protected override void CollisionTest(Attack attack)
        {
            // TODO -- only cast as as far as the projectile will move
            RaycastHit2D hit = Physics2D.Raycast(attack.transform.position, attack.transform.right, 1, attack.collisionMask);

            if(hit)
            {
                OnHit(attack, hit.transform.gameObject);
            }
        }

        protected override void OnHit(Attack attack, GameObject other)
        {
            // TODO -- projectile on hit
            // apply damage
            // try to bounce and pierce
        }
    }
}