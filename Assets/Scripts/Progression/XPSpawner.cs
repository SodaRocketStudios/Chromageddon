using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.Progression
{
	public class XPSpawner : MonoBehaviour
	{
		[SerializeField] private ObjectPool pool;

		public void Spawn(Vector2 position)
		{
			Experience experience = pool.Get(position) as Experience;
			experience.AddValue(1);
		}
	}
}