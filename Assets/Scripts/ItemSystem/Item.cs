using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;

namespace SRS.ItemSystem
{
	[CreateAssetMenu(fileName = "New Item", menuName = "Item System/Item")]
	public class Item : ScriptableObject
	{
		[SerializeField] new private string name;
		public string Name
		{
			get
			{
				return name;
			}
		}

		[SerializeField] private Sprite icon;
		
		[SerializeField] private ItemRarity rarity;
		public ItemRarity Rarity
		{
			get
			{
				return rarity;
			}
		}

		[SerializeField] private ItemCategory category;
		public ItemCategory Category
		{
			get
			{
				return category;
			}
		}

		[SerializeField] private List<ItemEffect> effects;
		public List<ItemEffect> Effects
		{
			get
			{
				return effects;
			}
		}

		[SerializeField, TextArea(2, 4)] private string description;
		public string Description
		{
			get
			{
				return description;
			}
		}

		public void Apply(CharacterStats stats)
		{
			foreach(ItemEffect effect in Effects)
			{
				effect.Apply(stats);
			}
		}

		public void Remove(CharacterStats stats)
		{
			foreach(ItemEffect effect in Effects)
			{
				effect.Apply(stats);
			}
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
		Health,
		Shield,
		Defense,
		Offense,
		Utility,
		ProcChance
	}
}