using UnityEngine;
using SRS.StatSystem;

namespace SRS.ItemSystem
{
	[System.Serializable]
	public class ItemEffectData
	{
		[SerializeField]
		private string stat;
		public string Stat
		{
			get
			{
				return stat;
			}
		}

		[SerializeField]
		private float intensity;
		public float Intensity
		{
			get
			{
				return intensity;
			}
		}

		[SerializeField]
		private ModifierType modifier;
		public ModifierType Modifier
		{
			get
			{
				return modifier;
			}
		}

		public void Apply(CharacterStats stats)
		{
			if(stats.Character.ContainsKey(Stat))
			{
				switch(Modifier)
				{
					case ModifierType.Additive:
						stats.Character[Stat].AdditiveModifier += Intensity;
						break;
					case ModifierType.Multiplicative:
						stats.Character[Stat].MultiplicativeModifier += Intensity;
						break;
					case ModifierType.Flat:
						stats.Character[Stat].FlatModifier += Intensity;
						break;
					default:
						break;
				}
			}

			if(stats.Attack.ContainsKey(Stat))
			{
				switch(Modifier)
				{
					case ModifierType.Additive:
						stats.Character[Stat].AdditiveModifier += Intensity;
						break;
					case ModifierType.Multiplicative:
						stats.Character[Stat].MultiplicativeModifier += Intensity;
						break;
					case ModifierType.Flat:
						stats.Character[Stat].FlatModifier += Intensity;
						break;
					default:
						break;
				}
			}
		}

		public void Remove(CharacterStats stats)
		{
			if(stats.Character.ContainsKey(Stat))
			{
				switch(Modifier)
				{
					case ModifierType.Additive:
						stats.Character[Stat].AdditiveModifier -= Intensity;
						break;
					case ModifierType.Multiplicative:
						stats.Character[Stat].MultiplicativeModifier -= Intensity;
						break;
					case ModifierType.Flat:
						stats.Character[Stat].FlatModifier -= Intensity;
						break;
					default:
						break;
				}
			}

			if(stats.Attack.ContainsKey(Stat))
			{
				switch(Modifier)
				{
					case ModifierType.Additive:
						stats.Character[Stat].AdditiveModifier -= Intensity;
						break;
					case ModifierType.Multiplicative:
						stats.Character[Stat].MultiplicativeModifier -= Intensity;
						break;
					case ModifierType.Flat:
						stats.Character[Stat].FlatModifier -= Intensity;
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