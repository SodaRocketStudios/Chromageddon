using System.Collections.Generic;
using UnityEngine;

namespace SRS.EnemySpawner
{
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject baseEnemy;

		[SerializeField]
		private Transform player;

		[SerializeField]
		private int minEnemies;
		[SerializeField]
		private int maxEnemies;

		private EnemyPool enemyPool;

		private SpawnLocator spawnLocator;

		private DynamicDifficultyManager difficultyManager;

		private void Start()
		{
			enemyPool = new EnemyPool(baseEnemy);
			spawnLocator = new SpawnLocator(player);
		}

		private void Update()
		{
			if(enemyPool.Count < minEnemies)
			{
				SpawnEnemy();
			}
		}

		private void SpawnEnemy()
		{
			enemyPool.Spawn();
		}
	}
}