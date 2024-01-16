using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using SRS.GameManagement;

namespace SRS.Items
{
	public class ItemChoicePanel : MonoBehaviour
	{
		[SerializeField] private GameObject itemButtonPrefab;

		private List<ItemSelectionButton> buttons;

		private Image background;

		// TODO -- figure out how to get players inventory.
		// Could be pased into the generate function.
		// That would also give access to the player level and stats to determine points.

		private void Awake()
		{
			background = GetComponent<Image>();
		}

		private void Start()
        {
			background.enabled = false;

            buttons = GetComponentsInChildren<ItemSelectionButton>().ToList();
            SetButtonsActive(false);
        }

        public void Generate()
		{
			Game.Instance.Pause();

			background.enabled = true;
			SetButtonsActive(true);

			PopulateChoices();
			// TODO -- Set items in buttons.
			// TODO -- Set proper gradient on buttons based on item rarity.
		}

		private void PopulateChoices()
		{
			// TODO -- determine points based on character level
			// Could also add luck stat into points.

			foreach(ItemSelectionButton button in buttons)
			{
				// button.Item = GetItem
			}
		}

		public void Close()
		{
			Game.Instance.Play();

			background.enabled = false;
			SetButtonsActive(false);
		}

        private void SetButtonsActive(bool active)
        {
            foreach (ItemSelectionButton button in buttons)
            {
                button.gameObject.SetActive(active);
            }
        }
	}
}