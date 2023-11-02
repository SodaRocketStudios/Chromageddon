using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Equippables/Weapon Data")]
	public class WeaponData : EquipableData
	{
		[SerializeField] private GameObject attackObject;
		public GameObject AttackObject
		{
			get => attackObject;
		}

		[SerializeField] DamageType damageType;
		public DamageType DamageType
		{
			get => DamageType;
		}
	}
}
