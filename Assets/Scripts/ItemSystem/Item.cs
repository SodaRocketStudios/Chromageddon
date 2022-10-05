using System.Collections.Generic;
using UnityEngine;

namespace SRS.ItemSystem
{
	[CreateAssetMenu(fileName = "New Item", menuName = "Item System/Item")]
	public class Item : ScriptableObject
	{
		[SerializeField]
		new private string name;
		public string Name
		{
			get
			{
				return name;
			}
		}

		[SerializeField]
		private Sprite icon;
		
		[SerializeField]
		private ItemRarity rarity;
		public ItemRarity Rarity
		{
			get
			{
				return rarity;
			}
		}

		[SerializeField]
		private ItemCategory category;
		public ItemCategory Category
		{
			get
			{
				return category;
			}
		}

		[SerializeField]
		private List<ItemEffectData> data;
		public List<ItemEffectData> Data
		{
			get
			{
				return data;
			}
		}

		[SerializeField, TextArea(2, 4)]
		private string description;
		public string Description
		{
			get
			{
				return description;
			}
		}
	}
}