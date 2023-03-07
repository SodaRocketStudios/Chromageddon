using System;
using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.EnemySpawner
{
	public class SpawnLocator
	{
		private Transform playerTransform;

		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

		private float minDistance = 1;

		private Bounds levelBounds;

		public SpawnLocator(Bounds level, float distance)
		{
			levelBounds = level;
			minDistance = distance;
		}

		public Vector2 GetLocation()
		{
			float randomX = (random.NextFloat() - 0.5f) * levelBounds.size.x + levelBounds.center.x;
			float randomY = (random.NextFloat() - 0.5f) * levelBounds.size.y + levelBounds.center.y;

			Vector2 position = new Vector2(randomX, randomY);

			Collider2D[] colliders = Physics2D.OverlapCircleAll(position, minDistance);

			foreach(Collider2D collider in colliders)
			{
				if(collider.isTrigger == false)
				{
					position = GetLocation();
				}
			}

			return position;
		}
	}
}