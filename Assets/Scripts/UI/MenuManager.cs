using UnityEngine;

namespace SRS.UI
{
	public class MenuManager : MonoBehaviour
	{
		public void Enable(GameObject menu)
		{
			menu.SetActive(true);
		}

		public void Disable(GameObject menu)
		{
			menu.SetActive(false);
		}
	}
}