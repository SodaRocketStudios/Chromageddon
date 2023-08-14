using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using SRS.Extensions;

namespace SRS.EnemySpawner
{
    public class EnemyShop
    {
        private List<GameObject> enemyTypes = new();

        public EnemyShop(List<GameObject> enemyTypes)
        {
            this.enemyTypes = enemyTypes;
        }

        public GameObject GetEnemy(int points)
        {
            return enemyTypes.Where(enemy => enemy.GetComponent<SpawnData>().Cost <= points).ToList().GetRandom();
        }
    }
}
