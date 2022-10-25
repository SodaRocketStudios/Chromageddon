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
            GameObject enemy = pool.Get();
            enemy.GetComponent<HealthManager>().OnDeath += Despawn;
            return enemy;
        }

        public void Despawn(GameObject enemy)
        {
            Debug.Log("Dead");
            enemy.GetComponent<HealthManager>().OnDeath -= Despawn;
            pool.Release(enemy);
        }

        private GameObject Create()
        {
            return GameObject.Instantiate(baseEnemy);
        }
    }
}