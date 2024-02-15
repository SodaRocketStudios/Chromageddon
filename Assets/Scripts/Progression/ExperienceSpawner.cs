using UnityEngine;
using SRS.Utils.ObjectPooling;
using System.Collections.Generic;

namespace SRS.Progression
{
	public class ExperienceSpawner : MonoBehaviour
	{
		[SerializeField] private ObjectPool pool;

		[SerializeField] private int softPickupCap;
		[SerializeField] private float mergeDistance;

		private List<Experience> activePickups = new();

		public void Spawn(Vector2 position, int value)
		{
			Experience experience = pool.Get(position) as Experience;
			experience.Value = value;

			if(activePickups.Count >= softPickupCap)
			{
				RaycastHit2D[] hits = Physics2D.CircleCastAll(position, mergeDistance, Vector2.right, 0, LayerMask.GetMask("XP"));
				foreach(RaycastHit2D hit in hits)
				{
					hit.transform.GetComponent<Experience>().StartMerge(experience);
				}
			}

			experience.OnPickup += Despawn;
			activePickups.Add(experience);
		}

		public void Despawn(Experience experience)
		{
			activePickups.Remove(experience);
			experience.ReturnToPool();
		}
	}
}