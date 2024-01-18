using System;
using UnityEngine;

namespace SRS.Progression
{
	[Serializable]
	public class XPMerger
	{
		[SerializeField] private float mergeRange;

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