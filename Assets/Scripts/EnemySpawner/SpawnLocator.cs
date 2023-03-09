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
		private float buffer;

		public SpawnLocator(Bounds levelBounds, float buffer, float distance)
		{
			this.levelBounds = levelBounds;
			this.buffer = buffer;
			this.minDistance = distance;
		}

		public Vector2 GetLocation()
		{
			float randomX = (random.NextFloat() - 0.5f) * (levelBounds.size.x + buffer) + levelBounds.center.x;
			float randomY = (random.NextFloat() - 0.5f) * (levelBounds.size.y + buffer) + levelBounds.center.y;

			Vector2 position = new Vector2(randomX, randomY);

			Collider2D[] colliders = Physics2D.OverlapCircleAll(position, minDistance, LayerMask.NameToLayer("Player"));

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