using UnityEngine;
using SRS.HealthProto;

namespace SRS
{
	public class EnemySpawner : MonoBehaviour
	{
		public int MinEnemies{private get; set;}
		public int MaxEnemies{private get; set;}

		private int enemyCount = 0;

		public float SpawnDelay{private get; set;}
		public int SpawnGroupSize{private get; set;}

		private float nextSpawnTime = 0;

		[SerializeField]private GameObject[] enemyTypes;

		private void Start()
		{
			MinEnemies = 1;
			MaxEnemies = 10;
			SpawnDelay = 5;
		}

		private void Update()
		{
			Vector2 spawnLocation = Random.insideUnitCircle*25;
			GameObject enemy = null;

			if(Time.time > nextSpawnTime && enemyCount < MaxEnemies)
			{
				enemy = SpawnEnemy(spawnLocation);
			}
			else if(enemyCount < MinEnemies)
			{
				enemy = SpawnEnemy(spawnLocation);
			}

			if(enemy != null)
			{
				enemy.GetComponent<HealthManagerProto>().OnDeath += DestroyEnemy;
			}
			
		}

		private GameObject SpawnEnemy(Vector2 position)
		{
			enemyCount++;
			nextSpawnTime = Time.time + SpawnDelay;
			return Instantiate(enemyTypes[0], position, Quaternion.identity);
		}

		private void DestroyEnemy(GameObject enemy)
		{
			Destroy(enemy);
			enemyCount--;
		}
	}
}