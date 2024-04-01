using UnityEngine;
using UnityEngine.EventSystems;

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

		[SerializeField] private GameObject FirstSelectedObject;

		public void Enable()
		{
			gameObject.SetActive(true);
			EventSystem.current.SetSelectedGameObject(FirstSelectedObject);
		}

		public void Disable()
		{
			gameObject.SetActive(false);
		}
	}
}