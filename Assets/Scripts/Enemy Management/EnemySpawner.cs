using System.Collections.Generic;
using UnityEngine;

namespace SRS.EnemyManagement
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private EnemySelector selector;
		[SerializeField] private SpawnLocator locator;

		private List<Enemy> activeEnemies;

		private int activeEnemyCount;
		private int maxActiveEnemies;
		
		private Transform player;
		// TODO -- if player == null then find player with a cast

		public void SpawnWave()
		{
			// TODO -- spawn and elitify enemies based on the current number of points.

			// TODO -- get teh number of points based on the current difficulty.
			int points = 10;

			while(points > 0)
			{
				EnemyData enemy = selector.SelectEnemyType(points);

				int amountToSpawn = points/enemy.Price;

				activeEnemyCount += amountToSpawn;

				while(activeEnemyCount > maxActiveEnemies)
				{
					// try to elitify enemies
				}
			}
			/*
				while points > 0
					get enemy type from shop
					determine the amount to spawn based on points and price
					pick a location
					amount = points/price ----- Round down
					remainingSpawns = SpawnCap
					while amount > 0
						elitifyingPoints = amount
						while elitifyingPoints >= remainingSpawns
							if(amount^elitifications < 0)
								amount = 0
								break
							Elitify the enemy
							elitifications++
							elitificationPoints /= SpawnCap ----- Round down
						amount -= SpawnCap^elitifications
						remainingSpawns --
			*/
		}

	}
}