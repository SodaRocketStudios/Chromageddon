using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;

namespace SRS.ItemSystem
{
	[System.Serializable]
	public class ItemEffect
	{
		[SerializeField] private string statName;
		public string StatName
		{
			get { return statName; }
		}

		[SerializeField] private ModifierType effectType;

		[SerializeField] private List<float> values;

		public List<float> Values
		{
			get 
			{
				return values;
			}
		}

		public void Apply(CharacterStats stats, ItemRarity rarity)
		{
			switch(effectType)
			{
				case ModifierType.Additive:
					stats.Stats[statName].BaseValue += values[(int)rarity];
					break;
				case ModifierType.Percentage:
					stats.Stats[statName].PercentageModifier += values[(int)rarity];
					break;
				case ModifierType.Multiplier:
					stats.Stats[statName].PercentageModifier *= values[(int)rarity];
					break;
				default:
					break;
			}
		}

		public void Remove(CharacterStats stats, ItemRarity rarity)
		{
			switch(effectType)
			{
				case ModifierType.Additive:
					stats.Stats[statName].BaseValue -= values[(int)rarity];
					break;
				case ModifierType.Percentage:
					stats.Stats[statName].PercentageModifier -= values[(int)rarity];
					break;
				case ModifierType.Multiplier:
					stats.Stats[statName].PercentageModifier /= values[(int)rarity];
					break;
				default:
					break;
			}
		}
	}

	public enum ModifierType
	{
		Additive,
		Percentage,
		Multiplier
	}
}