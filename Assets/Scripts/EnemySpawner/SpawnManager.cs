using System.Collections.Generic;
using UnityEngine;
using SRS.Health;
using SRS.Extensions;

namespace SRS.EnemySpawner
{
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField] private GameObject baseEnemy;
		[SerializeField] private List<GameObject> enemyTypes;

		[SerializeField] private Transform player;

		[SerializeField] private Transform level;

		[SerializeField] private int minEnemies;
		[SerializeField] private int maxEnemies;

		public GameObjectEvent OnEnemyDeath;

		private SpawnLocator spawnLocator;

		private DynamicDifficultyManager difficultyManager;

		private int enemyCount = 0;

		private void Start()
		{
			spawnLocator = new SpawnLocator(player, level);
		}

		private void Update()
		{
			// TODO Spawn based on a timer and the current challenge rating.

			if(enemyCount < minEnemies)
			{
				SpawnEnemy();
			}

			if(enemyCount < maxEnemies)
			{
				// Spawn enemies after a delay.
			}
		}

		private void SpawnEnemy()
		{
			// TODO -- Determine enemy type based on current challenge rating rather than randomly.

			GameObject enemy = Instantiate(enemyTypes.GetRandom(), spawnLocator.GetLocation(), Quaternion.identity);
			enemyCount++;
			enemy.GetComponent<HealthManager>().OnDeath += Despawn;
		}

		private void GetEnemyType()
		{

		}

		private void Despawn(GameObject enemy)
		{
			OnEnemyDeath.Invoke(enemy);

			Destroy(enemy);
			enemyCount--;
		}
	}
}