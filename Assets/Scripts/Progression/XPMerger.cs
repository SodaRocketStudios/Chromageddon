using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.Progression
{
	[Serializable]
	public class XPMerger
	{
		[SerializeField] private float mergeRange;

		public bool TryMerge(List<Experience> activePickups)
		{
			bool mergeSucceeded = false;

			foreach(Experience pickup in activePickups)
			{
				RaycastHit2D[] hits = Physics2D.CircleCastAll(pickup.transform.position, mergeRange, Vector2.right, 0, LayerMask.GetMask("XP"));

				// add each hit pickup to current pickup.
			}

			return mergeSucceeded;
		}
	}
}