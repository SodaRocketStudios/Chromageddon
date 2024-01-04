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

		[SerializeField] private float minDistanceFromPlayer;

		[SerializeField] private float spawnAreaSize = 1;

		[SerializeField] private float spawnDelay;
		[SerializeField, Min(1)] private float timerMultiplier;
		private float spawnTimer = 0;

		private List<Enemy> activeEnemies = new();
		
		private Transform player;

		System.Random randomGenerator = new(Guid.NewGuid().GetHashCode());

		private void Awake()
		{
			minDistanceFromPlayer += spawnAreaSize;
		}

		private void Start()
		{
			FindPlayer();
        }

		private void Update()
		{
			if(activeEnemies.Count <= 0)
			{
				spawnTimer += Time.deltaTime*timerMultiplier;
			}
			else
			{
				spawnTimer += Time.deltaTime;
			}

			if(spawnTimer >= spawnDelay)
			{
				SpawnWave();
				spawnTimer = 0;
			}
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
					// Debug.Log(locations[i]);
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
			Vector2 direction = randomGenerator.WithinUnitCircle().normalized;

			LayerMask mask = LayerMask.GetMask("Walls");

			RaycastHit2D hit = Physics2D.Raycast(player.transform.position, direction, int.MaxValue, mask);

			while(hit.distance - spawnAreaSize <= minDistanceFromPlayer)
			{
				direction = Quaternion.AngleAxis(90, Vector3.forward) * direction;
				hit = Physics2D.Raycast(player.transform.position, direction, int.MaxValue, mask);
			}

			float distance = randomGenerator.NextFloat(minDistanceFromPlayer, hit.distance - spawnAreaSize);

			Vector2 centroid = (Vector2)player.position + direction*distance;

			Debug.DrawLine(player.position, centroid, Color.red, 5);

			List<Vector2> locations = new();
			while(numberToSpawn > 0)
			{
				locations.Add(centroid + randomGenerator.WithinUnitCircle()*spawnAreaSize);

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