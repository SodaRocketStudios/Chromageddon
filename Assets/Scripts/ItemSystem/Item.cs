using System.Collections.Generic;
using UnityEngine;

namespace SRS.ItemSystem
{
	[CreateAssetMenu(fileName = "New Item", menuName = "Item System/Item")]
	public class Item : ScriptableObject
	{
		public string Name;

		[SerializeField]
		private Sprite icon;
		
		public ItemRarity Rarity;

		public List<ItemEffectData> Data = new List<ItemEffectData>();
		
	}
}