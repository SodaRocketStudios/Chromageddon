using UnityEngine;
using UnityEngine.Pool;

namespace SRS.EnemySpawner
{
    public class CreateEnemy
    {
        private GameObject enemyType;

        public CreateEnemy(GameObject enemyType)
        {
            this.enemyType = enemyType;
        }

        public GameObject Create()
        {
            GameObject enemy = Object.Instantiate(enemyType);
            enemy.SetActive(false);

            return enemy;
        }
    }
}
