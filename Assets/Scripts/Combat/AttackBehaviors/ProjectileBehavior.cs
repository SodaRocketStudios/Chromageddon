using SRS.Stats;
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
            RaycastHit2D hit = Physics2D.Raycast(attack.transform.position + attack.spriteSize.x*attack.transform.right, attack.transform.right, speed*Time.deltaTime, attack.collisionMask);

            Debug.DrawRay(attack.transform.position + attack.spriteSize.x*attack.transform.right, attack.transform.right*speed*Time.deltaTime, Color.red);

            if(hit)
            {
                OnHit(attack, hit.transform.gameObject);
            }
        }

        protected override void OnHit(Attack attack, GameObject other)
        {
            // TODO -- projectile on hit
            // apply damage
            // either move the projectile to show an actual collision, or cover up the gap with particles
            // try to bounce and pierce
            attack.Despawn();
        }

        public override float GetLifetime(StatContainer stats)
        {
            return stats["Range"].Value/speed;
        }
    }
}