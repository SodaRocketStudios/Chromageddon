using UnityEngine;

namespace SRS.EnemyManagement
{
	public abstract class SpawnLocator : ScriptableObject
	{
		public abstract Vector3 GetLocation(Transform player);
	}
}