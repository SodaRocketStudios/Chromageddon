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

		}

		public void Remove(CharacterStats stats)
		{

		}
	}

	public enum ModifierType
	{
		Additive,
		Multiplicative,
		Flat
	}
}