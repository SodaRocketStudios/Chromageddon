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
            GameObject enemy = GameObject.Instantiate(enemyType);
            enemy.SetActive(false);

            return enemy;
        }
    }
}
