using System;
using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.EnemyManagement
{
	[CreateAssetMenu(fileName = "Random Spawn Locator", menuName = "Enemies/Spawn Locators/ Random Spawn Locator")]
    public class RandomSpawnLocator : SpawnLocator
    {
		private System.Random randomGenerator = new(Guid.NewGuid().GetHashCode());

        public override Vector3 GetLocation(Transform player)
        {
			// TODO -- make enemies spawn farther from palyer, but still within the play area.
			// Could I do this by selecting an area within certain bounds?
			// I need a way to get the play area.
            return (Vector2)player.position + randomGenerator.WithinUnitCircle();
        }
    }
}