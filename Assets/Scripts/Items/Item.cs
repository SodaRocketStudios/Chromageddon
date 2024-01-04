using System.Collections.Generic;
using SRS.Stats;
using UnityEngine;

namespace SRS.Items
{
	[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
	public class Item : EquipableObject
	{
		private ItemRarity rarity;
		private List<string> tags;

		public void Apply(StatContainer stats)
		{
			Equip(stats);
		}

		public void Remove(StatContainer stats)
		{
			Unequip(stats);
		}

        protected override void OnEquip(StatContainer container)
        {
			// TODO -- On Item Equip
            throw new System.NotImplementedException();
        }

        protected override void OnUnequip(StatContainer container)
        {
			// TODO -- OnItemUnequip
            throw new System.NotImplementedException();
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