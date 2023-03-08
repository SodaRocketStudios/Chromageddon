using System.Collections.Generic;
using UnityEngine;
using SRS.Health;
using SRS.Extensions;
using SRS.GameManager;
using System;

namespace SRS.EnemySpawner
{
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField] private GameObject baseEnemy;
		[SerializeField] private List<GameObject> enemyTypes;

		[SerializeField] private Collider2D level;
		[SerializeField] private float levelBuffer;
		[SerializeField] private float spawnDistance;

		[SerializeField] private int minEnemies;
		[SerializeField] private int maxEnemies;

		[SerializeField] private float spawnDelay = 5;
		private float nextSpawnTime;

		public GameObjectEvent OnEnemyDeath;

		private SpawnLocator spawnLocator;

		private int enemyCount = 0;

		private void Start()
		{
			spawnLocator = new SpawnLocator(level.bounds, levelBuffer, spawnDistance);
		}

		private void Update()
		{
			if(enemyCount < minEnemies*DifficultyManager.Instance.ChallengeRating)
			{
				SpawnEnemy();
			}

			if(enemyCount < maxEnemies*DifficultyManager.Instance.ChallengeRating)
			{
				TrySpawnEnemy();
			}
		}

        private void TrySpawnEnemy()
        {
            if(Time.time > nextSpawnTime)
			{
				SpawnEnemy();
				nextSpawnTime += spawnDelay/DifficultyManager.Instance.ChallengeRating;
			}
        }

        private void SpawnEnemy()
		{
			// TODO -- Determine enemy type based on current challenge rating rather than randomly.

			GameObject enemy = Instantiate(enemyTypes.GetRandom(), spawnLocator.GetLocation(), Quaternion.identity);
			enemyCount++;
			enemy.GetComponent<HealthManager>().OnDeath.AddListener(Despawn);
		}

		private void GetEnemyType()
		{

		}

		private void Despawn(GameObject enemy)
		{
			OnEnemyDeath.Invoke(enemy);
			enemy.GetComponent<HealthManager>().OnDeath.RemoveListener(Despawn);

			Destroy(enemy);

			enemyCount--;
		}
	}
}