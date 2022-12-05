using UnityEngine;
using SRS.RandomOutcomeGenerator;

namespace SRS.ItemSystem
{
	[CreateAssetMenu(menuName = "Random Distribuition/Item Rarity Distribution", fileName = "New Item Rarity Distribution")]
	public class RarityDistribution : ScriptableObject
	{
		[SerializeField] private Distribution<ItemRarity> distribution;

		public ItemRarity GetRandom()
		{
			return distribution.GetRandom();
		}
	}
}