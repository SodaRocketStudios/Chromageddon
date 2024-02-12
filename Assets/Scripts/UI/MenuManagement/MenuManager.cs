using UnityEngine;

namespace SRS.UI.MenuManagement
{
	public class MenuManager : MonoBehaviour
	{
		[SerializeField] private Menu activeMenu;

		public void Switch(Menu menu)
		{
			activeMenu?.Disable();
			activeMenu = menu;
			activeMenu.Enable();
		}

		public void Close()
		{
			activeMenu?.Disable();
			activeMenu = null;
		}

		public void Back()
		{
			if(activeMenu.PreviousMenu != null)
			{
				Switch(activeMenu.PreviousMenu);
			}
			
			else if(activeMenu.CloseOnBack)
			{
				Close();
			}
		}
	}
}