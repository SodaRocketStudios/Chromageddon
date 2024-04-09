using UnityEngine;

namespace SRS.Combat
{
	public class WeaponSelectionManager : MonoBehaviour
	{
		public static WeaponSelectionManager Instance;

		[SerializeField] private AttackManager playerAttackManager;

		private WeaponSelectionButton currentSelection;

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(this);
			}
		}

		public void SetSelection(WeaponSelectionButton button)
		{
			currentSelection?.Deselect();
			currentSelection = button;
			playerAttackManager.Weapon = button.Weapon;
		}
	}
}