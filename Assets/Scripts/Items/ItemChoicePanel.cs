using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using SRS.GameManagement;
using SRS.Progression;
using System;

namespace SRS.Items
{
	public class ItemChoicePanel : MonoBehaviour
	{
		[SerializeField] private GameObject itemButtonPrefab;

		private List<ItemSelectionButton> buttons;

		private Image background;

		private Inventory targetInventory;

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

			foreach(ItemSelectionButton button in buttons)
			{
				button.OnSelect += OnItemSelect;
			}
        }

        public void Generate(CharacterLevel levelScript)
		{
			Game.Instance.Pause();

			background.enabled = true;
			SetButtonsActive(true);

			targetInventory = levelScript.GetComponent<Inventory>();

			float points = CalculatePoints();

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

		private void OnItemSelect(Item item)
        {
			if(targetInventory != null)
			{
				targetInventory.Add(item);
			}

            Close();
        }

        private float CalculatePoints()
        {
			// TODO -- calculate points based on current character level and luck.
			// Should game time play a role in this too so that players get a boost if they are behind?
            return 0;
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