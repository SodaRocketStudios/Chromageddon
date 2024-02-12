using UnityEngine;

namespace SRS.UI
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