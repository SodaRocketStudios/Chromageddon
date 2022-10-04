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

		public List<Item> GetItemsByRarity(ItemRarity rarity)
		{
			return new List<Item>(allItems.Where(item => item.Rarity == rarity));
		}

		public List<Item> GetItemsByCategory(ItemCategory category)
		{
			return new List<Item>(allItems.Where(item => item.Category == category));
		}
	}
}