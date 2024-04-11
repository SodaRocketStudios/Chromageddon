using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SRS.Achievements;

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
		[SerializeField] private TMP_Text descriptionTextBox;
		
		private Toggle toggleButton;

		private void Awake()
		{
			toggleButton = GetComponent<Toggle>();
			toggleButton.onValueChanged.AddListener(OnValueChange);
			
			GetComponent<LockableButton>().OnStateChange += PopulateText;
		}

		private void PopulateText()
		{
			nameTextBox.text = weapon.name;
			descriptionTextBox.text = GetComponent<LockableButton>().GetDescription();
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