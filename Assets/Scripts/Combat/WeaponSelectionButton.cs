using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SRS.Combat
{
	public class WeaponSelectionButton : MonoBehaviour
	{
		[SerializeField] private Weapon weapon;
		public Weapon Weapon
		{
			get => weapon;
		}

		[SerializeField] private TMP_Text nameTextBox;
		
		private Toggle toggleButton;

		private void Awake()
		{
			toggleButton = GetComponent<Toggle>();
			toggleButton.onValueChanged.AddListener(OnValueChange);

			nameTextBox.text = weapon.name;
		}

		public void Deselect()
		{
			toggleButton.SetIsOnWithoutNotify(false);
		}

		private void OnValueChange(bool value)
		{
			if(value == true)
			{
				WeaponSelectionManager.Instance.SetSelection(this);
			}
		}
	}
}