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
			get
			{
				return statName;
			}
		}

		[SerializeField] private float intensity;
		public float Intensity
		{
			get
			{
				return intensity;
			}
		}

		[SerializeField] private ModifierType modifier;
		public ModifierType Modifier
		{
			get
			{
				return modifier;
			}
		}

		public void Apply(CharacterStats stats)
		{
			if(stats.Character.ContainsKey(StatName))
			{
				switch(Modifier)
				{
					case ModifierType.Additive:
						stats.Character[StatName].AdditiveModifier += Intensity;
						break;
					case ModifierType.Multiplicative:
						stats.Character[StatName].MultiplicativeModifier += Intensity;
						break;
					case ModifierType.Flat:
						stats.Character[StatName].FlatModifier += Intensity;
						break;
					default:
						break;
				}
			}

			if(stats.Attack.ContainsKey(StatName))
			{
				switch(Modifier)
				{
					case ModifierType.Additive:
						stats.Attack[StatName].AdditiveModifier += Intensity;
						break;
					case ModifierType.Multiplicative:
						stats.Attack[StatName].MultiplicativeModifier += Intensity;
						break;
					case ModifierType.Flat:
						stats.Attack[StatName].FlatModifier += Intensity;
						break;
					default:
						break;
				}
			}
		}

		public void Remove(CharacterStats stats)
		{
			if(stats.Character.ContainsKey(StatName))
			{
				switch(Modifier)
				{
					case ModifierType.Additive:
						stats.Character[StatName].AdditiveModifier -= Intensity;
						break;
					case ModifierType.Multiplicative:
						stats.Character[StatName].MultiplicativeModifier -= Intensity;
						break;
					case ModifierType.Flat:
						stats.Character[StatName].FlatModifier -= Intensity;
						break;
					default:
						break;
				}
			}

			if(stats.Attack.ContainsKey(StatName))
			{
				switch(Modifier)
				{
					case ModifierType.Additive:
						stats.Character[StatName].AdditiveModifier -= Intensity;
						break;
					case ModifierType.Multiplicative:
						stats.Character[StatName].MultiplicativeModifier -= Intensity;
						break;
					case ModifierType.Flat:
						stats.Character[StatName].FlatModifier -= Intensity;
						break;
					default:
						break;
				}
			}
		}
	}

	public enum ModifierType
	{
		Additive,
		Multiplicative,
		Flat
	}
}