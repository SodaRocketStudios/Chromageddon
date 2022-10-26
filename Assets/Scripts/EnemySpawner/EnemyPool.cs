using UnityEngine;
using UnityEngine.Pool;
using SRS.Health;

namespace SRS.EnemySpawner
{
    public class EnemyPool
    {
        public int Count
        {
            get{return pool.CountActive;}
        }

        private ObjectPool<GameObject> pool;

        private GameObject baseEnemy;

        public EnemyPool(GameObject baseEnemy)
        {
            this.baseEnemy = baseEnemy;
            pool = new ObjectPool<GameObject>(Create);
        }

        public GameObject Spawn()
        {
            // TO DO -- Set enemy data
            GameObject enemy = pool.Get();
            enemy.SetActive(true);
            return enemy;
        }

        public void Despawn(GameObject enemy)
        {
            enemy.SetActive(false);
            pool.Release(enemy);
        }

        private GameObject Create()
        {
            GameObject enemy = GameObject.Instantiate(baseEnemy);
            enemy.GetComponent<HealthManager>().OnDeath += Despawn;
            return enemy;
        }
    }
}