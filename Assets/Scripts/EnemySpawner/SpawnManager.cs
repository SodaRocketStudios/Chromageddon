using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SRS.Health;
using SRS.Extensions;
using SRS.GameManager;
using SRS.LevelSystem;

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
		[SerializeField] private float initialSpawnDelay = 1;
		private float nextSpawnTime;

		[SerializeField] private XPDropper xpDropper;

		public GameObjectEvent OnEnemyDeath;

		private SpawnLocator spawnLocator;

		private int enemyCount = 0;

		private void Start()
		{
			spawnLocator = new SpawnLocator(level.bounds, levelBuffer);
			nextSpawnTime = GameTimer.Instance.Time + initialSpawnDelay;
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
			int numberToSpawn = (int)Mathf.Max(minGroupSize, Mathf.Round(maxGroupSize*DifficultyManager.Instance.ChallengeRating));

			for(int i = 0; i < numberToSpawn; i++)
			{
				SpawnEnemy();
			}

			nextSpawnTime = GameTimer.Instance.Time + spawnDelaySeconds;
		}

        private void SpawnEnemy()
		{
			GameObject enemy = Instantiate(GetEnemyType(), spawnLocator.GetLocation(minDistanceFromPlayer), Quaternion.identity);
			enemyCount++;
			enemy.GetComponent<HealthManager>().OnDeath.AddListener(Despawn);
		}

		private GameObject GetEnemyType()
		{
			return enemyTypes.Where(enemy => enemy.GetComponent<SpawnData>().CanSpawn(GameTimer.Instance.Time)).ToList<GameObject>().GetRandom<GameObject>();
		}

		private void Despawn(GameObject enemy)
		{
			OnEnemyDeath.Invoke(enemy);
			enemy.GetComponent<HealthManager>().OnDeath.RemoveListener(Despawn);

			xpDropper.SpawnXP(enemy.transform.position);

			Destroy(enemy);

			enemyCount--;
		}
	}
}