using UnityEngine;
using SRS.Audio;

namespace SRS.AttackSystem
{
	[CreateAssetMenu(fileName = "Basic Ranged Attack", menuName = "Old/Attacks/Basic Ranged Attack")]
	public class BasicRangedAttack : AttackType
	{
		[SerializeField] private float projectileSpeed;

        public override void Attack(Transform origin, float attackAngle, LayerMask mask)
        {
			Quaternion direction = Quaternion.Euler(0, 0, origin.eulerAngles.z+Random.Range(-attackAngle/2, attackAngle/2));

			GameObject projectileInstance = ProjectileSpawner.Instance.Spawn(origin.position + origin.right, direction);
			projectileInstance.GetComponent<Projectile>().Speed = projectileSpeed;
			
			projectileInstance.GetComponent<Projectile>().Initialize(characterStats, mask);

			AudioManager.Instance.PlayEffect("Shoot");
        }
	}
}