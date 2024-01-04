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

		[SerializeField, Min(1)] private int maxEnemies;

		[SerializeField] private Rect spawnArea;

		private List<Enemy> activeEnemies = new();
		
		private Transform player;
		// TODO -- if player == null then find player with a cast

		System.Random randomGenerator = new(Guid.NewGuid().GetHashCode());

		// TODO -- spawn enemies at set intervals. Maybe change the interval if there are no active enemies.

		private void Start()
		{
			FindPlayer();
        }

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

				while(amountToSpawn > enemy.MaxGroupSize)
				{
					elitifications++;
					amountToSpawn /= 2;
				}

				List<Vector2> locations = GetGroupSpawnLocations(amountToSpawn);

				for(int i = 0; i < amountToSpawn; i++)
				{
					if(activeEnemies.Count >= maxEnemies)
					{
						if(TryRecycleEnemy() == false)
						{
							continue;
						}
					}

					Enemy newEnemy = enemyPool.Get(locations[i]) as Enemy;
					newEnemy.Initialize(enemy, elitifications);
					activeEnemies.Add(newEnemy);
					points -= enemy.Price*(int)Mathf.Pow(2, elitifications);
				}
			}
		}

		public void Despawn(Enemy enemy)
		{
			activeEnemies.Remove(enemy);
			enemy.ReturnToPool();
		}

		private List<Vector2> GetGroupSpawnLocations(int numberToSpawn)
		{
			// TODO -- spawn enemies away from player but within play area.
			Vector2 Centroid = randomGenerator.WithinRect(spawnArea);

			List<Vector2> locations = new();
			while(numberToSpawn > 0)
			{
				locations.Add(Centroid + randomGenerator.WithinUnitCircle());

				numberToSpawn--;
			}
			return locations;
		}

        private bool TryRecycleEnemy()
		{
			foreach(Enemy enemy in activeEnemies)
			{
				if(enemy.IgnoreRecycleRequests == false)
				{
					Debug.Log("Recycled", enemy.gameObject);
					Despawn(enemy);
					return true;
				}
			}
			return false;
		}

		private void FindPlayer()
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}
}