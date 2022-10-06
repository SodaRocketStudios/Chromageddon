using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SRS.GameManager;

namespace SRS.ItemSystem
{
	public class ItemSelectionPanel : MonoBehaviour
	{
		public static ItemSelectionPanel Instance;

		[SerializeField]
		private GameObject buttonPrefab;

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

			background = GetComponent<Image>();
		}

		public void GenerateSelectionPanel(List<Item> items, Inventory targetInventory)
		{
			Game.Instance.Pause();

			background.enabled = true;

			foreach(Item item in items)
			{
				if(item == null)
				{
					continue;
				}

				GameObject button = Instantiate(buttonPrefab);
				button.transform.SetParent(transform, false);

				button.GetComponentInChildren<TextMeshProUGUI>().text = item.Name;

				button.GetComponent<Button>().onClick.AddListener(DisableSelectionPanel);
				button.GetComponent<Button>().onClick.AddListener(delegate{targetInventory.AddItem(item);});

				buttons.Add(button);
			}
		}

		private void DisableSelectionPanel()
		{
			background.enabled = false;

			foreach(GameObject button in buttons)
			{
				button.GetComponent<Button>().onClick.RemoveAllListeners();
				Destroy(button);
			}

			buttons.Clear();

			Game.Instance.Play();
		}
	}
}