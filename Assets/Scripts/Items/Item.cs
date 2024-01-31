using System.Collections.Generic;
using SRS.Stats;
using UnityEngine;

namespace SRS.Items
{
	[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
	public class Item : EquipableObject
	{
		// TODO -- figure out how to trigger item behaviors at the right time.
		// Item behaviors can be broken into different types like on hit, on heal, etc.
		// then they can subscribe to the correct events.
		[SerializeField] private List<ItemBehavior> behaviors;

		[SerializeField] private ItemRarity rarity;
		public ItemRarity Rarity
		{
			get => rarity;
		}

		[SerializeField] private List<string> tags;

		public void Apply(StatContainer stats)
		{
			Equip(stats);
			Debug.Log(RichTextDescription);
		}

		public void Remove(StatContainer stats)
		{
			Unequip(stats);
		}

        protected override void OnEquip(StatContainer container)
        {
			// TODO -- On Item Equip
        }

        protected override void OnUnequip(StatContainer container)
        {
			// TODO -- OnItemUnequip
        }
    }
}