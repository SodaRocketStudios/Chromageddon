using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using SRS.Extensions.Random;
using SRS.GameManagement;
using SRS.Progression;
using SRS.UI;
using SRS.Utils.Curves;
using SRS.Stats;

namespace SRS.Items
{
	public class ItemChoicePanel : MonoBehaviour
	{
		[SerializeField] private GameObject itemButtonPrefab;

		[SerializeField] private ItemDatabase itemDatabase;

		private DescriptionFormat descriptionFormat;
		public DescriptionFormat DescriptionFormat
		{
			set
			{
				descriptionFormat = value;

				foreach(ItemSelectionButton button in buttons)
				{
					button.Draw(targetInventory.GetComponent<StatContainer>(), descriptionFormat);
				}
			}
		}

		private List<ItemSelectionButton> buttons;

		private Image background;

		private Inventory targetInventory;

		private System.Random randomGenerator = new System.Random(Guid.NewGuid().GetHashCode());

		private SigmoidCurve luckCurve = new(2, 0, 0, .01f);

		private bool isActive = false;

		private int itemChoices = 0;

		private int level;

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

			itemChoices++;

			if(isActive)
			{
				return;
			}

			background.enabled = true;
			SetButtonsActive(true);

			isActive = true;

			targetInventory = levelScript.GetComponent<Inventory>();

			level = levelScript.Level;

			float points = CalculatePoints(level);

			PopulateChoices(points);
		}

        private void PopulateChoices(float points)
		{
			EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
			
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

				button.GetComponent<HoldButton>().Reset();

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

				button.Item = possibleItems[randomGenerator.Next(possibleItems.Count)];

				button.Draw(targetInventory.GetComponent<StatContainer>(), descriptionFormat);

				selectedItems.Add(button.Item);
			}
		}

		public void Close()
		{
			Game.Instance.Play();

			background.enabled = false;
			SetButtonsActive(false);

			isActive = false;
		}

		public void ToggleFormat(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				if(isActive)
				{
					DescriptionFormat = descriptionFormat == DescriptionFormat.Absolute ? DescriptionFormat.Relative : DescriptionFormat.Absolute;
				}
			}
		}

		private void OnItemSelect(Item item)
        {
			if(targetInventory != null)
			{
				targetInventory.Add(item);
			}

			itemChoices--;

            if(itemChoices > 0)
			{
				level++;
				PopulateChoices(CalculatePoints(level));
				return;
			}

			Close();
        }

        private float CalculatePoints(int level)
        {
			// TODO -- Should play time play a role in points to help players that are falling behind.
			float points = level*luckCurve.Evaluate(targetInventory.GetComponent<StatContainer>()["Luck"].Value);
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
	
	public enum DescriptionFormat
	{
		Absolute,
		Relative
	}
}