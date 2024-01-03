using System.Collections.Generic;
using SRS.Stats;
using UnityEngine;

namespace SRS.Items
{
	[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
	public class Item : ScriptableObject
	{
		private new string name;
		private List<StatModifier> statModifications;
		private ItemRarity rarity;
		private List<string> tags;

		public void Apply(StatContainer stats)
		{
			foreach(StatModifier modifier in statModifications)
			{
				modifier.Apply(stats);
			}
		}

		public void Remove(StatContainer stats)
		{
			foreach(StatModifier modifier in statModifications)
			{
				modifier.Remove(stats);
			}
		}
	}

    enum ItemRarity
    {
		Common,
		Uncommon,
		Rare,
		Legendary
    }
}