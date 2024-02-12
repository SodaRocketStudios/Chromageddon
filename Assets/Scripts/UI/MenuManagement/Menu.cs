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