using UnityEngine;

namespace SRS.AttackProto
{
	public class RangedAttackProto : AttackTypeProto
	{
		private GameObject projectile;

		public RangedAttackProto(GameObject _projectile)
		{
			projectile = _projectile;
		}

        public override void Attack(Transform origin, LayerMask mask)
        {
			// fire a projectile with a random angle determine by spread
			// also need to add in the player's speed.
			int sign = (int)Mathf.Sign(Random.value - 0.5f);
			Quaternion direction = Quaternion.Euler(0, 0, origin.eulerAngles.z+Random.Range(0, 15.0f)*sign);
			GameObject newProjectile = GameObject.Instantiate(projectile, origin.position, direction);
        }
    }
}