using UnityEngine;

namespace SRS.EnemyManagement
{
	public abstract class EnemySelector : ScriptableObject
	{
		[SerializeField] private EnemyDatabase database;

		public abstract EnemyData SelectEnemyType(float points);
	}
}