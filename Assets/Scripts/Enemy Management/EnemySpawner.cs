using System;
using System.Collections.Generic;
using SRS.Utils.ObjectPooling;
using UnityEngine;

namespace SRS.EnemyManagement
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private EnemySelector selector;
		[SerializeField] private SpawnLocator locator;

		[SerializeField] private ObjectPool enemyPool;

		private List<Enemy> activeEnemies;

		private int activeEnemyCount;
		private int maxActiveEnemies;
		
		private Transform player;
		// TODO -- if player == null then find player with a cast

		System.Random randomGenerator = new(Guid.NewGuid().GetHashCode());

		public void SpawnWave()
		{
			// TODO -- get the number of points based on the current difficulty.
			int points = 10;

			while(points > 0)
			{
				EnemyData enemy = selector.SelectEnemyType(points);

				int maxAffordable = points/enemy.Price;

				int amountToSpawn = randomGenerator.Next(1, maxAffordable);

				int elitifications = 0;

				while(amountToSpawn > enemy.maxGroupSize)
				{
					elitifications++;
					amountToSpawn /= 2;
				}

				while(amountToSpawn > 0)
				{
					// TODO -- set the position of each enemy. Ideally spawn them in clusters.
					Enemy newEnemy = enemyPool.Get() as Enemy;
					newEnemy.Initialize(enemy, elitifications);
					points -= enemy.Price*(int)Mathf.Pow(2, elitifications);
					amountToSpawn--;
				}
			}
		}

	}
}