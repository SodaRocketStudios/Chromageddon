using UnityEngine;

namespace SRS.UI.MenuManagement
{
	public class Menu : MonoBehaviour
	{
		[SerializeField] private GameObject panel;

		[SerializeField] private Menu previousMenu;

		public void Enable()
		{
			panel.SetActive(true);
		}

		public void Disable()
		{
			panel.SetActive(false);
		}
	}
}