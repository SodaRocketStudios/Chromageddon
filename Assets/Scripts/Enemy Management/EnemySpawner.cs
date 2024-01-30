using System;
using System.Collections.Generic;
using UnityEngine;
using SRS.Utils.ObjectPooling;
using SRS.Utils.VFX;
using SRS.Progression;
using SRS.Extensions.Random;

namespace SRS.EnemyManagement
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private EnemySelector selector;

		[SerializeField] private ObjectPool enemyPool;

		[SerializeField] private AudioClip deathSound;

		[SerializeField] private ParticleManager deathParticleManager;

		[SerializeField, Min(1)] private int maxEnemies;

		[SerializeField] private float minDistanceFromPlayer;

		[SerializeField] private float spawnAreaRadius = 1;

		[SerializeField] private float spawnDelay;
		[SerializeField, Min(1)] private float timerMultiplier;
		private float spawnTimer = 0;

		[SerializeField] private int initialPoints = 5;
		[SerializeField, Min(1.001f)] private float pointsMultiplier;
		private float pointsExponent = 1;

		[SerializeField] private ExperienceSpawner experienceSpawner;

		private AudioSource audioSource;

		private List<Enemy> activeEnemies = new();
		
		private Transform player;

		System.Random randomGenerator = new(Guid.NewGuid().GetHashCode());

		private void Awake()
		{
			minDistanceFromPlayer += spawnAreaRadius;

			audioSource = GetComponent<AudioSource>();
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
			int points = initialPoints*(int)Mathf.Pow(pointsMultiplier, pointsExponent);
			pointsExponent++;

			while(points >= 1)
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
					newEnemy.OnEnemyDeath += KillEnemy;
					newEnemy.Initialize(enemy, elitifications);
					activeEnemies.Add(newEnemy);
					points -= enemy.Price*(int)Mathf.Pow(2, elitifications);
				}
			}
		}

		public void KillEnemy(Enemy enemy)
		{
			experienceSpawner.Spawn(enemy.transform.position, enemy.XPValue);
			audioSource.PlayOneShot(deathSound);
			deathParticleManager.PlayParticles(enemy.transform.position, Quaternion.identity, enemy.Color);
			Despawn(enemy);
		}

		public void Despawn(Enemy enemy)
		{
			activeEnemies.Remove(enemy);
			enemy.OnEnemyDeath -= KillEnemy;
			enemy.ReturnToPool();
		}

		private List<Vector2> GetGroupSpawnLocations(int numberToSpawn)
		{
			Vector2 direction = randomGenerator.WithinUnitCircle().normalized;

			LayerMask mask = LayerMask.GetMask("Walls");

			RaycastHit2D hit = Physics2D.Raycast(player.transform.position, direction, int.MaxValue, mask);

			while(hit.distance - spawnAreaRadius <= minDistanceFromPlayer)
			{
				direction = Quaternion.AngleAxis(90, Vector3.forward) * direction;
				hit = Physics2D.Raycast(player.transform.position, direction, int.MaxValue, mask);
			}

			float distance = randomGenerator.NextFloat(minDistanceFromPlayer, hit.distance - spawnAreaRadius);

			Vector2 centroid = (Vector2)player.position + direction*distance;

			List<Vector2> locations = new();

			for(int i = 0; i < numberToSpawn; i++)
			{
				hit = Physics2D.Raycast(player.transform.position, direction, spawnAreaRadius, mask);
				if(hit)
				{
					distance = randomGenerator.NextFloat(0, hit.distance);
				}
				else
				{
					distance = randomGenerator.NextFloat(0, spawnAreaRadius);
				}

				direction = randomGenerator.WithinUnitCircle().normalized;

				locations.Add(centroid + direction*distance);
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