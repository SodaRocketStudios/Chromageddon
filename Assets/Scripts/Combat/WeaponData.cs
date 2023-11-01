using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Equippables/Weapon Data")]
	public class WeaponData : EquipableData
	{
		[SerializeField] private AttackCollider attackCollider;
		public AttackCollider AttackCollider
		{
			get => attackCollider;
		}

		[SerializeField] DamageType damageType;
		public DamageType DamageType
		{
			get => DamageType;
		}
	}
}
