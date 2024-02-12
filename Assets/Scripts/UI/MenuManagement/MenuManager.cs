using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SRS.UI.MenuManagement
{
	public class MenuManager : MonoBehaviour
	{
		public UnityEvent OnClose;

		[SerializeField] private Menu activeMenu;

		[SerializeField] private Menu pauseMenu;

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
			OnClose?.Invoke();
		}

		public void Pause(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				Switch(pauseMenu);
			}
		}

		public void Back(InputAction.CallbackContext context)
		{
			if(!context.performed)
			{
				return;
			}

			if(activeMenu == null)
			{
				return;
			}

			if(activeMenu.CloseOnBack)
			{
				Close();
			}
			else if(activeMenu.PreviousMenu != null)
			{
				Switch(activeMenu.PreviousMenu);
			}
		}
	}
}