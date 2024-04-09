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

		private Toggle toggleButton;

		private void Awake()
		{
			toggleButton = GetComponent<Toggle>();
			toggleButton.onValueChanged.AddListener(OnValueChange);
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