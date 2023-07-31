using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SRS.GameManager;
using SRS.UI;

namespace SRS.ItemSystem
{
	public class ItemSelectionPanel : MonoBehaviour
	{
		public static ItemSelectionPanel Instance;

		[SerializeField] private GameObject buttonPrefab;

		[SerializeField] private GameObject skipButton;

		private ItemPicker itemPicker;

		private Image background;

		private List<GameObject> buttons = new List<GameObject>(3);

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
		}

		private void Start()
		{
			itemPicker = GetComponent<ItemPicker>();
		}

		public void GenerateSelectionPanel(Inventory targetInventory)
		{
			
			Game.Instance.Pause();

			background.enabled = true;
			skipButton.SetActive(true);

			List<Item> items = itemPicker.PickItems();

			foreach(Item item in items)
			{

				if(item == null)
				{
					continue;
				}

				GameObject button = Instantiate(buttonPrefab);
				button.transform.SetParent(transform, false);

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
				Destroy(button);
			}

			buttons.Clear();

			Game.Instance.Play();
		}
	}
}