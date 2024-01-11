using UnityEngine;

namespace SRS.Combat
{
	public class WeaponSelectionButton : MonoBehaviour
	{
		private Weapon weapon;
		public Weapon Weapon {get; set;}

		private AttackManager attackManager;
		public AttackManager AttackManager{get; set;}
	}
}