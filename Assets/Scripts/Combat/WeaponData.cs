using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Equippables/Weapon Data")]
	public class WeaponData : EquipableData
	{
		[SerializeField] private GameObject attackPrefab;
		public GameObject AttackObject
		{
			get => attackPrefab;
		}
	}
}
