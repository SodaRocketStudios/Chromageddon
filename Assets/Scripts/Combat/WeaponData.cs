using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Equipables/Weapon Data")]
	public class WeaponData : EquipableData
	{
		[SerializeField] private GameObject attackPrefab;
		public GameObject AttackObject
		{
			get => attackPrefab;
		}

		public override void Equip(StatContainer container)
		{
			container.gameObject.GetComponent<Weapon>().WeaponData = this;
			base.Equip(container);
		}

		public override void Remove(StatContainer container)
		{
			container.gameObject.GetComponent<Weapon>().WeaponData = null;
			base.Remove(container);
		}
	}
}
