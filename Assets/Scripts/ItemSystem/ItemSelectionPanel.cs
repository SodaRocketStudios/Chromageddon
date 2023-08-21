using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SRS.GameManager;
using SRS.UI;
using SRS.StatSystem;
using SRS.Extensions;

namespace SRS.ItemSystem
{
	public class ItemSelectionPanel : MonoBehaviour
	{
		public static ItemSelectionPanel Instance;

		[SerializeField] private GameObject buttonPrefab;

		[SerializeField] private GameObject skipButton;

		[SerializeField] private int NumberOfItemChoices = 3;

		[SerializeField] private int minPoints;
		[SerializeField] private int maxPoints;

		private Image background;

		private List<GameObject> buttons;

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(gameObject);
			}

			background = GetComponentInParent<Image>();

			buttons = new List<GameObject>(NumberOfItemChoices);

			minPoints = Mathf.Max(minPoints, NumberOfItemChoices);
		}

		public void GenerateSelectionPanel(Inventory targetInventory)
		{
			
			Game.Instance.Pause();

			background.enabled = true;
			skipButton.SetActive(true);

			int points = (int)Mathf.Max(minPoints, maxPoints * DifficultyManager.Instance.ChallengeRating);

			List<Item> items = new();

			for(int i = 0; i < NumberOfItemChoices; i++)
			{
				int remainingChoices = NumberOfItemChoices - i - 1;
				Item item;
				do
				{
					item = GetItem(points - remainingChoices);
				}while(items.Contains(item));

				do
				{
					item.Rarity = ItemDatabase.Instance.GetRarity();
				}while(item.Cost > points - remainingChoices);

				items.Add(item);

				points -= item.Cost;
			}

			CharacterStats stats = targetInventory.GetComponent<CharacterStats>();

			foreach(Item item in items)
			{

				if(item == null)
				{
					continue;
				}

				GameObject button = Instantiate(buttonPrefab, transform);

				button.GetComponentInChildren<TextMeshProUGUI>().text = item.Name;

				ColorChangeAnimation colorAnimation = button.GetComponent<ColorChangeAnimation>();

				Color color = ItemDatabase.Instance.RarityColors[item.Rarity];
				colorAnimation.StartColor = color;
				float h, s, v;
				Color.RGBToHSV(color, out h, out s, out v);
				s = 0.1f;
				color = Color.HSVToRGB(h, s, v);
				colorAnimation.EndColor = color;

				HoldButton holdComponent = button.GetComponent<HoldButton>();
				holdComponent.OnHoldCompleted.AddListener(DisableSelectionPanel);
				holdComponent.OnHoldCompleted.AddListener(delegate{targetInventory.AddItem(item);});

				HoverDisplay hoverDisplay = GetComponent<HoverDisplay>();
				holdComponent.OnPointerHoverEvent.AddListener(hoverDisplay.Show);
				holdComponent.OnPointerHoverEvent.AddListener(hoverDisplay.UpdatePosition);
				holdComponent.OnPointerHoverEndEvent.AddListener(hoverDisplay.Hide);

				string hoverText = $"{item.Description}\n\nCurrent: {stats[item.Effects[0].StatName]}";
				holdComponent.OnPointerHoverEvent.AddListener(delegate{hoverDisplay.SetText(hoverText);});

				buttons.Add(button);
			}
		}

		public void DisableSelectionPanel()
		{
			background.enabled = false;
			skipButton.SetActive(false);

			foreach(GameObject button in buttons)
			{
				HoldButton holdComponent = button.GetComponent<HoldButton>();
				holdComponent.OnHoldCompleted.RemoveAllListeners();
				holdComponent.OnPointerHoverEvent.RemoveAllListeners();
				holdComponent.OnPointerHoverEndEvent.RemoveAllListeners();
				GetComponent<HoverDisplay>().Hide();
				Destroy(button);
			}

			buttons.Clear();

			Game.Instance.Play();
		}

		private Item GetItem(int points)
        {
            return ItemDatabase.Instance.GetItems().Where(item => item.Cost <= points).ToList().GetRandom();
        }
	}
}