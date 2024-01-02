using System;
using System.Collections.Generic;
using UnityEngine;
using SRS.Utils.ObjectPooling;
using SRS.Extensions.Random;

namespace SRS.EnemyManagement
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private EnemySelector selector;

		[SerializeField] private ObjectPool enemyPool;

		private List<Enemy> activeEnemies;

		private int activeEnemyCount;
		private int maxActiveEnemies;
		
		private Transform player;
		// TODO -- if player == null then find player with a cast

		System.Random randomGenerator = new(Guid.NewGuid().GetHashCode());

		// TODO -- spawn enemies at set intervals. Maybe change the interval if there are no active enemies.

		[ContextMenu("SpawnEnemies")]
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

				List<Vector2> locations = GetGroupSpawnLocations(amountToSpawn);

				for(int i = 0; i < amountToSpawn; i++)
				{
					Enemy newEnemy = enemyPool.Get(locations[i]) as Enemy;
					newEnemy.Initialize(enemy, elitifications);
					points -= enemy.Price*(int)Mathf.Pow(2, elitifications);
				}
			}
		}

		private List<Vector2> GetGroupSpawnLocations(int numberToSpawn)
		{
			// TODO -- spawn enemies away from player but within play area.
			List<Vector2> locations = new();
			while(numberToSpawn > 0)
			{
				locations.Add(randomGenerator.WithinUnitCircle());

				numberToSpawn--;
			}
			return locations;
		}
	}
}