using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using SRS.GameManagement;
using SRS.Progression;

namespace SRS.Items
{
	public class ItemChoicePanel : MonoBehaviour
	{
		[SerializeField] private GameObject itemButtonPrefab;

		private List<ItemSelectionButton> buttons;

		private Image background;

		private Inventory targetInventory;

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

			float points = CalculatePoints(levelScript);

			PopulateChoices(points);
			// TODO -- Set proper gradient on buttons based on item rarity.
		}

        private void PopulateChoices(float points)
		{
			foreach(ItemSelectionButton button in buttons)
			{
				// TODO -- Pick items and set them for buttons.
				// button.Item = GetItem

				// TODO -- set gradient colors on button based on item rarity.


				// Select rarity randomly based on points
				// select item of rarity
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

        private float CalculatePoints(CharacterLevel levelScript)
        {
			// TODO -- determine points based on character level
			// Could also add luck stat into points. luck is converted to a multiplier by sigmoid function.
			// Should game time play a role in this too so that players get a boost if they are behind?
			float points = levelScript.Level;
            return points;
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