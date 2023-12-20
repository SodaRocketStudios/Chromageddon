using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.Combat
{
	public class Attack : PooledObject
	{
		private AttackBehavior behavior;
		
		public GameObject Source;

		private float lifetime; // send back to pool when time is up.

		public void Initialize()
		{
			// this needs to set the source of the attack, the attacker stats, and the behavior of the attack
			// also set any visuals of the attack
			// would this be easier if I create an attack data scriptable object that can be passed from the weapon.
		}


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