using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.Combat
{
	public class Attack : PooledObject
	{
		[SerializeField] private AttackBehavior behavior;

		private float lifetime; // send back to pool when time is up.

		private void OnSpawn()
		{
			// set correct behavior.
			// set the sprite.
		}

		private void Update()
		{
			// check for hits -- maybe do this in fixed update
			// update visuals
			// do specific behavior (Bouncing, piercing, sweeping, thrusting) -- cast behavior is weapon specific
			// projectiles and lasers use circle/raycast, thrus is a box cast, sweep is an arc.
			// hit behaviors are the harder implementation -- could pas the game object to the update of the behavior.
		}
	}
}