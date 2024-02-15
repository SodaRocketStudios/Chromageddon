using System;
using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = " New Random Projectile Behavior", menuName = "Combat/Attack Behavior/Random Projectile Behavior")]
    public class RandomProjectileBehavior : AttackBehavior
    {
        [SerializeField] private float speed = 1;
		[SerializeField] private float randomizedAngle;

        private Transform player;

        private System.Random random = new(Guid.NewGuid().GetHashCode());

        public override void OnStart(Attack attack)
        {
            if(player == null)
            {
                FindPlayer();
            }
            Vector3 rotation = new(0, 0, random.NextFloat(-randomizedAngle/2, randomizedAngle/2));
            attack.transform.right = player.position - attack.transform.position;
            attack.transform.Rotate(rotation);
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
            RaycastHit2D hit = Physics2D.Raycast(attack.transform.position + attack.spriteSize.x*attack.transform.right, attack.transform.right, speed*Time.deltaTime, attack.CollisionMask);

            if(hit)
            {
                if(hit.transform.gameObject != attack.LastHitObject)
                {
                    Hit(attack, hit);
                }
            }
        }

        protected override void OnHit(Attack attack, RaycastHit2D hit)
        {
            attack.Despawn();
        }

        public override float GetLifetime(Attack attack)
        {
            return attack.Stats["Range"].Value/speed;
        }

        private void FindPlayer()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}