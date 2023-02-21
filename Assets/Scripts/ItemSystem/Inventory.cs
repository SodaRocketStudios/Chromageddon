using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;

namespace SRS.ItemSystem
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField]
		private List<Item> starterItems;
		private Dictionary<string, int> items = new Dictionary<string, int>();

		private CharacterData characterData;

		private void Awake()
		{
			characterData = GetComponent<CharacterData>();
		}

		private void Start()
		{
			AddStarterItems();
		}

		public void AddItem(Item item)
		{
			if(!items.ContainsKey(item.Name))
			{
				items[item.name] = 0;
			}

			items[item.name]++;

			item.Apply(characterData);
		}

		public void RemoveItem(Item item)
		{
			items[item.name] --;

			item.Remove(characterData);
		}

		private void AddStarterItems()
		{
			foreach(Item item in starterItems)
			{
				AddItem(item);
			}
		}
	}
}