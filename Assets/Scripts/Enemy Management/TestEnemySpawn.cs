using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.EnemyManagement
{
	public class TestEnemySpawn : MonoBehaviour
	{
		public ObjectPool enemyPool;
		public EnemyData data;

		private void Update()
		{
			Enemy enemy = enemyPool.Get().GetComponent<Enemy>();
			enemy.Initialize(data);
		}
	}
}