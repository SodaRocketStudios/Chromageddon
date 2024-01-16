using UnityEngine;
using SRS.Utils.ObjectPooling;
using System.Collections.Generic;

namespace SRS.Progression
{
	public class XPSpawner : MonoBehaviour
	{
		[SerializeField] private ObjectPool pool;

		[SerializeField] private int softPickupCap;

		[SerializeField] private XPMerger merger = new();

		private List<Experience> activePickups = new();

		public void Spawn(Vector2 position)
		{
			int value = 1;

			if(activePickups.Count >= softPickupCap)
			{
				value += merger.TryMerge(position);

				Debug.Log(value);
			}

			Experience experience = pool.Get(position) as Experience;
			experience.OnPickup += Despawn;
			activePickups.Add(experience);
			experience.Value = value;
		}

		public void Despawn(Experience experience)
		{
			activePickups.Remove(experience);
			experience.gameObject.SetActive(false);
		}
	}
}