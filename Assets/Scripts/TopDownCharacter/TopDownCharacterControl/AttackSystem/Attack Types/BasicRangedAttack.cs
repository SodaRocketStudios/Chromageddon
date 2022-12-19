using UnityEngine;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	[CreateAssetMenu(fileName = "Basic Ranged Attack", menuName = "Attacks/Basic Ranged Attack")]
	public class BasicRangedAttack : AttackType
	{
		[SerializeField] private GameObject projectile;

        public override void Attack(Transform origin, float attackAngle, LayerMask mask)
        {
			Quaternion direction = Quaternion.Euler(0, 0, origin.eulerAngles.z+Random.Range(-attackAngle/2, attackAngle/2));

			GameObject projectile = ProjectileSpawner.Instance.Pool.Get();

			projectile.transform.rotation = direction;
			projectile.transform.position = origin.position + origin.right;
			
			projectile.GetComponent<Projectile>().Initialize(attackStats, mask);
        }
	}
}