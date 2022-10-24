using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace SRS
{
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject objectToPool;

		[SerializeField]
		private List<GameObject> enemyTypes = new List<GameObject>();

		[SerializeField]
		private int minEnemies;
		private int maxEnemies;

		private ObjectPool<GameObject> enemyPool;

		private void Start()
		{
			enemyPool = new ObjectPool<GameObject>(
				() => {return Instantiate(objectToPool);}
				);

			SpawnEnemy();
		}

		private void SpawnEnemy()
		{
			enemyPool.Get();
		}
	}
}