using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.EnemyManagement
{
    public class EnemyShop : EnemySelector
    {
		System.Random randomGenerator = new(Guid.NewGuid().GetHashCode());

        public override EnemyData SelectEnemyType(float points)
        {
			List<EnemyData> availableEnemies = new();

            foreach (EnemyData enemy in database.Enemies)
			{
				if(enemy.price <= points)
				{
					availableEnemies.Add(enemy);
				}
			}

			int randomIndex = randomGenerator.Next(0, availableEnemies.Count-1);

			return availableEnemies[randomIndex];

        }
    }
}