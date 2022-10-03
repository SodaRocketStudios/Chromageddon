using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SRS.ItemSystem
{
	public class ItemDatabase : MonoBehaviour
	{
		public static ItemDatabase Instance;

		public static List<Item> allItems = new List<Item>();

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

		// TO DO -- Use Linq to create functions to return items based on criteria.

		// public List<Item> GetItemsOfRarity(ItemRarity rarity)
		// {
		// 	return from item in allItems where item.Rarity == rarity select item;
		// }
	}
}