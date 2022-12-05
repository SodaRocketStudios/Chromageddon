using System;
using UnityEngine;

namespace SRS.EnemySpawner
{
	public class SpawnLocator
	{
		private Transform playerTransform;

		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

		private int minDistance = 20;

		private Rect levelBounds;

		public SpawnLocator(Transform player, Transform level)
		{
			playerTransform = player;

			levelBounds.size = level.localScale - Vector3.one*5;
			levelBounds.position = level.position;
		}

		public Vector2 GetLocation()
		{
			int randomX = random.Next((int)-levelBounds.width/2, (int)levelBounds.width/2) + (int)levelBounds.position.x;
			int randomY = random.Next((int)-levelBounds.height/2, (int)levelBounds.height/2) + (int)levelBounds.position.y;

			Vector2 position = new Vector2(randomX, randomY);

			if(Vector2.Distance(playerTransform.position, position) < minDistance)
			{
				Vector2 direction = (position - (Vector2)playerTransform.position).normalized;
				position += direction*minDistance;
			}

			position.x = Mathf.Clamp(position.x, -levelBounds.width/2, levelBounds.width/2);
			position.y = Mathf.Clamp(position.y, -levelBounds.height/2, levelBounds.height/2);

			return position;
		}
	}
}