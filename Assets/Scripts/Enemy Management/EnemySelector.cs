using UnityEngine;

namespace SRS.EnemyManagement
{
	public abstract class EnemySelector : ScriptableObject
	{
		[SerializeField] protected EnemyDatabase database;

		public abstract EnemyData SelectEnemyType(float points);
	}
}