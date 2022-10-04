using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SRS.ItemSystem
{
	public class ItemDatabase : MonoBehaviour
	{
		public static ItemDatabase Instance;

		[SerializeField]
		private List<Item> allItems;

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
		}

		public Item GetItemByName(string name)
		{
			return allItems.Where(item => item.Name == name) as Item;
		}

		public List<Item> GetItems()
		{
			return allItems;
		}

		public List<Item> GetItems(ItemRarity rarity)
		{
			return new List<Item>(allItems.Where(item => item.Rarity == rarity));
		}

		public List<Item> GetItems(ItemCategory category)
		{
			return new List<Item>(allItems.Where(item => item.Category == category));
		}

		public List<Item> GetItems(ItemRarity rarity, ItemCategory category)
		{
			return new List<Item>(allItems.Where(item => item.Rarity == rarity && item.Category == category));
		}

		public Item GetRandomItem()
		{
			return GetRandomItemFromList(allItems);
		}

		public Item GetRandomItem(ItemRarity rarity)
		{
			List<Item> itemOptions = GetItems(rarity);
			return GetRandomItemFromList(itemOptions);
		}

		public Item GetRandomItem(ItemCategory category)
		{
			List<Item> itemOptions = GetItems(category);
			return GetRandomItemFromList(itemOptions);
		}

		public Item GetRandomItem(ItemRarity rarity, ItemCategory category)
		{
			List<Item> itemOptions = GetItems(rarity, category);
			return GetRandomItemFromList(itemOptions);
		}

		private Item GetRandomItemFromList(List<Item> items)
		{
			System.Random randomGenerator = new System.Random(System.DateTime.Now.Millisecond);
			return items[randomGenerator.Next(items.Count)];
		}
	}
}