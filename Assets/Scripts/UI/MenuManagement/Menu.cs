using UnityEngine;

namespace SRS.UI.MenuManagement
{
	public class Menu : MonoBehaviour
	{
		[SerializeField] private Menu previousMenu;
		public Menu PreviousMenu
		{
			get => previousMenu;
		}

		[SerializeField] private bool closeOnBack;
		public bool CloseOnBack
		{
			get => closeOnBack;
		}

		public void Enable()
		{
			gameObject.SetActive(true);
		}

		public void Disable()
		{
			gameObject.SetActive(false);
		}
	}
}