using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.TopDownCharacterController.AttackSystem
{
	public class RangedAttack : AttackType
	{
		private GameObject projectile;

		public RangedAttack(Dictionary<string, Stat> stats, GameObject _projectile)
		{
			UpdateStats(stats);
			projectile = _projectile;
		}

        public override void Attack(Transform origin, float attackAngle, LayerMask mask)
        {
			Quaternion direction = Quaternion.Euler(0, 0, origin.eulerAngles.z+Random.Range(-attackAngle/2, attackAngle/2));
			GameObject newProjectile = GameObject.Instantiate(projectile, origin.position, direction);

			// TO DO -- Set projectile stats and collider mask.
        }
	}
}