using UnityEngine;
using SRS.Utils.ObjectPooling;
using System.Collections.Generic;

namespace SRS.Progression
{
	public class XPSpawner : MonoBehaviour
	{
		[SerializeField] private ObjectPool pool;

		[SerializeField] private int maxActivePickups;

		[SerializeField] private XPMerger merger = new();

		private List<Experience> activePickups = new();

		public void Spawn(Vector2 position)
		{
			if(activePickups.Count >= maxActivePickups)
			{
				merger.TryMerge(activePickups);
			}

			Experience experience = pool.Get(position) as Experience;
			experience.OnPickup += Despawn;
			activePickups.Add(experience);
			experience.Value = 1;
		}

		public void Despawn(Experience experience)
		{
			activePickups.Remove(experience);
			experience.gameObject.SetActive(false);
		}
	}
}