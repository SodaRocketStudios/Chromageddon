using System.Collections.Generic;
using UnityEngine;

namespace SRS.Items
{
	[CreateAssetMenu(fileName = "New Item Database", menuName = "Items/Database")]
	public class ItemDatabase : ScriptableObject
	{
		[SerializeField] private List<Item> items;
		public List<Item> Items
		{
			get => items;
		}

		[SerializeField] private List<ItemRarity> rarities;
		public List<ItemRarity> Rarities
		{
			get => rarities;
		}
	}
}