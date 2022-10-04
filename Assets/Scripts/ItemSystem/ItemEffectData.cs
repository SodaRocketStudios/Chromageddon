using UnityEngine;
using SRS.Stats;

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
	}
	
	public enum ItemRarity
	{
		Common,
		Uncommon,
		Rare,
		Legendary,
		Boss
	}
}