using System.Collections.Generic;
using UnityEngine;
using SRS.Health;
using SRS.Extensions;
using SRS.GameManager;

namespace SRS.EnemySpawner
{
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField] private GameObject baseEnemy;
		[SerializeField] private List<GameObject> enemyTypes;

		[SerializeField] private Collider2D level;
		[SerializeField] private float levelBuffer;
		[SerializeField] private float minDistanceFromPlayer;

		[SerializeField] private int minGroupSize;
		[SerializeField] private int maxGroupSize;

		[SerializeField] private int maxEnemies;

		[SerializeField] private float spawnDelaySeconds = 5;
		private float nextSpawnTime;

		public GameObjectEvent OnEnemyDeath;

		private SpawnLocator spawnLocator;

		private int enemyCount = 0;

		private void Start()
		{
			spawnLocator = new SpawnLocator(level.bounds, levelBuffer, minDistanceFromPlayer);
			nextSpawnTime = GameTimer.Instance.Time;
		}

		private void Update()
		{
			if(GameTimer.Instance.Time >= nextSpawnTime)
			{
				SpawnGroup();
			}
		}

		private void SpawnGroup()
		{
			Debug.Log(minGroupSize);
			int numberToSpawn = (int)Mathf.Max(minGroupSize, Mathf.Round(maxGroupSize*DifficultyManager.Instance.ChallengeRating));
			Debug.Log(DifficultyManager.Instance.ChallengeRating);

			Debug.Log($"Spawn: {numberToSpawn} at: {GameTimer.Instance.Time}");

			for(int i = 0; i < numberToSpawn; i++)
			{
				SpawnEnemy();
			}

			nextSpawnTime = GameTimer.Instance.Time + spawnDelaySeconds;
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