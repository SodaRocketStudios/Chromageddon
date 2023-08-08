using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SRS.Health;
using SRS.Extensions;
using SRS.GameManager;
using SRS.LevelSystem;
using SRS.Audio;

namespace SRS.EnemySpawner
{
	public class SpawnManager : MonoBehaviour
	{
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

		private EnemyPool enemyPool;

		private int enemyCount = 0;

		private void Start()
		{
			spawnLocator = new SpawnLocator(level.bounds, levelBuffer);
			nextSpawnTime = GameTimer.Instance.Time + initialSpawnDelay;

			enemyPool = new EnemyPool(enemyTypes);
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
			GameObject enemyType = GetEnemyType();
			GameObject enemy = enemyPool.Get(enemyType);
			enemy.transform.position = spawnLocator.GetLocation(minDistanceFromPlayer);
			enemyCount++;
			enemy.GetComponent<HealthManager>().OnDeath.AddListener(Despawn);

			ReturnToPool returnToPool = enemy.GetComponent<ReturnToPool>();

			if(returnToPool.Pool == null)
			{
				returnToPool.Pool = enemyPool.GetPool(enemyType);
			}
		}

		private GameObject GetEnemyType()
		{
			return enemyTypes.Where(enemy => enemy.GetComponent<SpawnData>().CanSpawn(GameTimer.Instance.Time)).ToList<GameObject>().GetRandom<GameObject>();
		}

		private void Despawn(GameObject enemy)
		{
			OnEnemyDeath.Invoke(enemy);
			enemy.GetComponent<HealthManager>().OnDeath.RemoveListener(Despawn);

			enemy.GetComponent<ReturnToPool>().Release();

			xpDropper.SpawnXP(enemy.transform.position);

			enemyCount--;

			AudioManager.Instance.PlayEffect("Enemy Death");
		}
	}
}