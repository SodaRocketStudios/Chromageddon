using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.ItemSystem
{
	public class ItemDatabase : MonoBehaviour
	{
		public static ItemDatabase Instance;

		[SerializeField] private List<Item> allItems;

		[SerializeField] private List<Color> rarityColors = new();
		public Dictionary<ItemRarity, Color> RarityColors = new();

		[SerializeField] private List<int> rarityDrawChances = new();
		public Dictionary<ItemRarity, int> RarityDrawChances = new();

		private int totalDrawChances;

		System.Random randomGenerator = new System.Random(DateTime.Now.Millisecond);

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

			int i = 0;

			foreach(ItemRarity rarity in Enum.GetValues(typeof(ItemRarity)))
			{
				RarityColors.Add(rarity, rarityColors[i]);
				RarityDrawChances.Add(rarity, rarityDrawChances[i]);
				totalDrawChances += rarityDrawChances[i];
				i++;
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

		public ItemRarity GetRarity()
		{
			int randomDraw = (int)randomGenerator.NextFloat()*totalDrawChances;

			foreach(KeyValuePair<ItemRarity, int> drawChance in RarityDrawChances)
			{
				if(randomDraw <= drawChance.Value)
				{
					return drawChance.Key;
				}
			}

			return ItemRarity.Common;
		}

		private Item GetRandomItemFromList(List<Item> items)
		{
			if(items.Count < 1)
			{
				return null;
			}

			return items[randomGenerator.Next(items.Count)];
		}
	}

	public enum ItemRarity
	{
		Common,
		Uncommon,
		Rare,
		Legendary,
		Boss
	}

	public enum ItemCategory
	{
		Defense,
		Offense,
		Utility
	}
}