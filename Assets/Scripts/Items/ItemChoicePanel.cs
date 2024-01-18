using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using SRS.Extensions.Random;
using SRS.GameManagement;
using SRS.Progression;
using SRS.UI;

namespace SRS.Items
{
	public class ItemChoicePanel : MonoBehaviour
	{
		[SerializeField] private GameObject itemButtonPrefab;

		[SerializeField] private ItemDatabase itemDatabase;

		private List<ItemSelectionButton> buttons;

		private Image background;

		private Inventory targetInventory;

		private System.Random randomGenerator = new System.Random(Guid.NewGuid().GetHashCode());

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
		}

        private void PopulateChoices(float points)
		{
			List<Item> selectedItems = new();

			foreach(ItemSelectionButton button in buttons)
			{
				float pointAllotment = randomGenerator.NextFloat(1, points);
				ItemRarity selectedRarity = null;

				foreach(ItemRarity rarity in itemDatabase.Rarities)
				{
					if(pointAllotment >= rarity.PointRequirement)
					{
						if(selectedRarity == null)
						{
							selectedRarity = rarity;
							continue;
						}

						if(rarity.PointRequirement > selectedRarity.PointRequirement)
						{
							selectedRarity = rarity;
						}
					}
				}

				GradientColorKey[] colorKeys =
				{
					new GradientColorKey(selectedRarity.Color, 0),
					new GradientColorKey(Color.white, 1)
				};

				GradientAlphaKey[] alphaKeys =
				{
					new GradientAlphaKey(1, 1)
				};

				Gradient rarityGradient = new();
				rarityGradient.SetKeys(colorKeys, alphaKeys);

				button.GetComponent<ColorChangeAnimation>().Gradient = rarityGradient;


				List<Item> possibleItems = new();
				
				// TODO -- consider item tags when selecting

				foreach(Item item in itemDatabase.Items.Where(item => item.Rarity.name == selectedRarity.name))
				{
					if(selectedItems.Contains(item))
					{
						continue;
					}

					possibleItems.Add(item);
				}


				button.Item = possibleItems[randomGenerator.Next(0, possibleItems.Count)];

				selectedItems.Add(button.Item);
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