using UnityEngine;

namespace SRS.Items
{
	[CreateAssetMenu(fileName = "New Item Rarity", menuName = "Items/Rarity")]
	public class ItemRarity : ScriptableObject
	{
		[SerializeField] private new string name;
		public string Name
		{
			get => name;
		}

		[SerializeField] private Color color;
		public Color Color
		{
			get => color;
		}

		[SerializeField] private float pointRequirement;
		public float PointRequirement
		{
			get => pointRequirement;
		}
	}
}