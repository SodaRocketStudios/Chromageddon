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

		[SerializeField] private EffectType effectType;

		[SerializeField] private List<float> values;

		public void Apply(CharacterStats stats, ItemRarity rarity)
		{
			switch(effectType)
			{
				case EffectType.Additive:
					stats.Stats[statName].BaseValue += values[(int)rarity];
					break;
				case EffectType.Percentage:
					stats.Stats[statName].PercentageModifier += values[(int)rarity];
					break;
				case EffectType.Multiplier:
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
				case EffectType.Additive:
					stats.Stats[statName].BaseValue -= values[(int)rarity];
					break;
				case EffectType.Percentage:
					stats.Stats[statName].PercentageModifier -= values[(int)rarity];
					break;
				case EffectType.Multiplier:
					stats.Stats[statName].PercentageModifier /= values[(int)rarity];
					break;
				default:
					break;
			}
		}
	}

	public enum EffectType
	{
		Additive,
		Percentage,
		Multiplier
	}
}