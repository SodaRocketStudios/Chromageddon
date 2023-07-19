using System;
using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.EnemySpawner
{
	public class SpawnLocator
	{
		private Transform playerTransform;

		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

		private Bounds levelBounds;
		private float buffer;

		public SpawnLocator(Bounds levelBounds, float buffer)
		{
			this.levelBounds = levelBounds;
			this.buffer = buffer;
		}

		public Vector2 GetLocation(float minDistance)
		{
			int tries = 0;

			Vector2 position;

			Collider2D player;

			do
			{
				float randomX = (random.NextFloat() - 0.5f) * (levelBounds.size.x + buffer) + levelBounds.center.x;
				float randomY = (random.NextFloat() - 0.5f) * (levelBounds.size.y + buffer) + levelBounds.center.y;

				position = new Vector2(randomX, randomY);

				player = Physics2D.OverlapCircle(position, minDistance, LayerMask.GetMask("Player"));

				tries++;
			} while(player != null && tries < 25);

			return position;
		}
	}
}