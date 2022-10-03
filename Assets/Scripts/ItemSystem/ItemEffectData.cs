using SRS.Stats;

namespace SRS.ItemSystem
{
	[System.Serializable]
	public class ItemEffectData
	{
		public string stat;
		public float intensity;
		public ModifierType modifier;
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