using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	[CreateAssetMenu(fileName = "Basic Ranged Attack", menuName = "Attacks/Basic Ranged Attack")]
	public class BasicRangedAttack : AttackType
	{
		[SerializeField] private GameObject projectile;

        public override void Attack(Transform origin, float attackAngle, LayerMask mask)
        {
			Quaternion direction = Quaternion.Euler(0, 0, origin.eulerAngles.z+Random.Range(-attackAngle/2, attackAngle/2));
			Projectile newProjectile = GameObject.Instantiate(projectile, origin.position, direction).GetComponent<Projectile>();
			newProjectile.Initialize(attackStats, mask);
        }
	}
}