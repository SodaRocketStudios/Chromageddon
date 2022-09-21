using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.TopDownCharacterController.AttackSystem
{
	public class RangedAttack : AttackType
	{
		private GameObject projectile;

		public RangedAttack(Dictionary<string, Stat> stats)
		{
			UpdateStats(stats);
		}

        public override void Attack(Transform origin, LayerMask mask)
        {
			float spreadAngle = attackStats["AttackArc"].Value;

			Quaternion direction = Quaternion.Euler(0, 0, origin.eulerAngles.z+Random.Range(-spreadAngle/2, spreadAngle/2));
			GameObject newProjectile = GameObject.Instantiate(projectile, origin.position, direction);

			// TO DO -- Set projectile collider mask.
        }
	}
}