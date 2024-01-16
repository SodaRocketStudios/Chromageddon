using UnityEngine;
using UnityEngine.UI;
using SRS.GameManagement;

namespace SRS.HUD
{
	public class ItemChoicePanel : MonoBehaviour
	{
		[SerializeField] private GameObject itemButtonPrefab;

		private Image background;

		private void Awake()
		{
			background = GetComponent<Image>();
		}

		public void Generate()
		{
			background.enabled = true;

			Game.Instance.Pause();

			// TODO -- Pause the game.

			GetItemChoices();

			// TODO -- generate buttons for items.
		}

		private void GetItemChoices()
		{
			// TODO -- determine points based on character level
			// Could also add luck stat into points.
		}

		public void Close()
		{
			background.enabled = false;

			// TODO -- Make sure that buttons are removed with the background image.

			Game.Instance.Play();
		}
	}
}