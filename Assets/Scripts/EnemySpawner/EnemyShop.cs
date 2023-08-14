using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using SRS.Extensions;

namespace SRS.EnemySpawner
{
    public class EnemyShop
    {
        private List<GameObject> enemyTypes = new();
        private Dictionary<GameObject, SpawnData> spawnData = new();

        public EnemyShop(List<GameObject> enemyTypes)
        {
            this.enemyTypes = enemyTypes;
            foreach(GameObject enemy in enemyTypes)
            {
                spawnData[enemy] = enemy.GetComponent<SpawnData>();
            }
        }

        public GameObject GetEnemy(int points)
        {
            return enemyTypes.Where(enemy => spawnData[enemy].Cost <= points).ToList().GetRandom();
        }
    }
}
