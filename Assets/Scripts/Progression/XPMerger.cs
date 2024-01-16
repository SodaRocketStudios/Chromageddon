using System;
using System.Collections.Generic;
using UnityEngine;
using SRS.Extensions.Vector;

namespace SRS.Progression
{
	[Serializable]
	public class XPMerger
	{
		[SerializeField] private float mergeRange;

		// public bool TryMerge(List<Experience> activePickups)
		// {
		// 	bool mergeSucceeded = false;

		// 	foreach(Experience pickup in activePickups)
		// 	{
		// 		RaycastHit2D[] hits = Physics2D.CircleCastAll(pickup.transform.position, mergeRange, Vector2.right, 0, LayerMask.GetMask("XP"));

		// 		List<Vector3> locations = new()
        //         {
        //             pickup.transform.position
        //         };

		// 		foreach(RaycastHit2D hit in hits)
		// 		{
		// 			locations.Add(hit.transform.position);
		// 		}

		// 		Vector3 centroid = VectorExtensions.Average(locations);

		// 		foreach(RaycastHit2D hit in hits)
		// 		{
		// 			hit.transform.GetComponent<Experience>().Merge(pickup);
		// 		}
		// 	}

		// 	return mergeSucceeded;
		// }

		public int TryMerge(Vector3 mergeLocation)
		{
			int value = 0;

			RaycastHit2D[] hits = Physics2D.CircleCastAll(mergeLocation, mergeRange, Vector2.right, 0, LayerMask.GetMask("XP"));

			foreach(var hit in hits)
			{
				Experience experience = hit.transform.GetComponent<Experience>();
				value += experience.Value;
				experience.Merge();
			}

			return value;
		}
	}
}