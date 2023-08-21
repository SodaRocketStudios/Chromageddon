using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;
using System.Text.RegularExpressions;

namespace SRS.ItemSystem
{
	[CreateAssetMenu(fileName = "New Item", menuName = "Item System/Item")]
	public class Item : ScriptableObject
	{
		[SerializeField] new private string name;
		public string Name
		{
			get { return name; }
		}

		[SerializeField] private int cost;
		public int Cost
		{
			get { return (int)Mathf.Pow(2, (int)Rarity)*cost; }
		}

		[SerializeField] private Sprite icon;
		public Sprite Icon
		{
			get{ return icon; }
		}

		[SerializeField] private ItemCategory category;
		public ItemCategory Category
		{
			get{ return category; }
		}

		[SerializeField] private List<ItemEffect> effects;
		public List<ItemEffect> Effects
		{
			get { return effects; }
		}

		[SerializeField, TextArea(2, 4)] private string description;
		public string Description
		{
			get { return FormatDescription(); }
		}

		public ItemRarity Rarity{ get; set; }

		public void Apply(CharacterStats stats)
		{
			foreach(ItemEffect effect in Effects)
			{
				effect.Apply(stats, Rarity);
			}
		}

		public void Remove(CharacterStats stats)
		{
			foreach(ItemEffect effect in Effects)
			{
				effect.Remove(stats, Rarity);
			}
		}

		private string FormatDescription()
		{
			string formattedDescription = Regex.Replace(description, "/N", effects[0].StatName);
			formattedDescription = Regex.Replace(formattedDescription, "/V", effects[0].Values[(int)Rarity].ToString());
			return formattedDescription;
		}
	}
}