using UnityEngine;

namespace SRS.TopDownCharacterController.AttackSystem
{
	public class RangedAttack : AttackType
	{
		public float SpreadAngle{get; set;}

		private GameObject projectile;

		public RangedAttack(GameObject _projectile, float _spreadAngle)
		{
			projectile = _projectile;
			SpreadAngle = _spreadAngle;
		}

        public override void Attack(Transform origin, LayerMask mask)
        {
			Quaternion direction = Quaternion.Euler(0, 0, origin.eulerAngles.z+Random.Range(-SpreadAngle/2, SpreadAngle/2));
			GameObject newProjectile = GameObject.Instantiate(projectile, origin.position, direction);

			// TO DO -- Set projectile collider mask.
        }
	}
}