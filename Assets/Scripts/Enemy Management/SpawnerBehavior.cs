using System;
using UnityEngine;
using SRS.Combat;
using SRS.Extensions.Random;

namespace SRS.EnemyManagement
{
    [CreateAssetMenu(fileName = "New Spawner Behavior", menuName = "Combat/Attack Behavior/Spawner Behavior")]
    public class SpawnerBehavior : AttackBehavior
    {
        [SerializeField] private EnemyData enemyToSpawn;

        [SerializeField] private int amountTospawn;

        [SerializeField] private float distanceFromSpawner;

        private EnemySpawner spawner;

        private System.Random random = new(Guid.NewGuid().GetHashCode());

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
            if(spawner == null)
            {
                FindSpawner();
            }
            
            for(int i = 0; i < amountTospawn; i++)
            {
                Vector2 location = (Vector2)attack.transform.position + random.WithinUnitCircle().normalized*distanceFromSpawner;
                spawner.SpawnEnemy(enemyToSpawn, location);
            }
        }

        private void FindSpawner()
        {
            spawner = FindAnyObjectByType<EnemySpawner>();
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