using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SRS.ItemSystem
{
	public class ItemDatabase : MonoBehaviour
	{
		public static ItemDatabase Instance;

		[SerializeField]
		private List<Item> items;
		public static List<Item> allItems;

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(this);
			}

			allItems = new List<Item>(items);
		}

		// TO DO -- Use Linq to create functions to return items based on criteria.

		public List<Item> GetItemsOfRarity(ItemRarity rarity)
		{
			return new List<Item>(allItems.Where(item => item.Rarity == rarity));
		}

		public Item GetItemByName(string name)
		{
			return allItems.Where(item => item.Name == name) as Item;
		}
	}
}