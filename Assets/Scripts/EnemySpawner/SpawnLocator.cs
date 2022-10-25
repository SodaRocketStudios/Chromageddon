using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.EnemySpawner
{
	public class SpawnLocator
	{
		private Transform playerTransform;

		public SpawnLocator(Transform player)
		{
			playerTransform = player;
		}

		public Vector2 GetLocation()
		{
			return new Vector2();
		}
	}
}