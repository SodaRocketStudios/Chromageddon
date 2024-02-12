using UnityEngine;

namespace SRS.UI.MenuManagement
{
	public class MenuManager : MonoBehaviour
	{
		private Menu activeMenu;
		
		public void Enable(GameObject menu)
		{
			menu.SetActive(true);
		}

		public void Disable(GameObject menu)
		{
			menu.SetActive(false);
		}

		public void Switch(Menu menu)
		{
			activeMenu.Disable();
			activeMenu = menu;
			activeMenu.Enable();
		}

		public void Close()
		{
			activeMenu.Disable();
		}
	}
}