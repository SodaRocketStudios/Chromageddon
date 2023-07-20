using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace SRS.EnemySpawner
{
    [System.Serializable]
    public class EnemyPool
    {
        private Dictionary<GameObject, ObjectPool<GameObject>> enemyPools = new Dictionary<GameObject, ObjectPool<GameObject>>();
        private Dictionary<GameObject, CreateEnemy> enemyCreationFunctions = new Dictionary<GameObject, CreateEnemy>();

        public EnemyPool(List<GameObject> enemyTypes)
        {
            foreach(GameObject enemyType in enemyTypes)
            {
                enemyCreationFunctions.Add(enemyType, new CreateEnemy(enemyType));
                enemyPools.Add(enemyType, new ObjectPool<GameObject>(enemyCreationFunctions[enemyType].Create, OnGet, OnReturn));
            }
        }

        public GameObject Get(GameObject enemyType)
        {
            return enemyPools[enemyType].Get();
        }

        public ObjectPool<GameObject> GetPool(GameObject enemytype)
        {
            return enemyPools[enemytype];
        }

		private void OnGet(GameObject enemy)
		{
			enemy.SetActive(true);
		}

		private void OnReturn(GameObject enemy)
		{
			enemy.SetActive(false);
		}
    }
}
