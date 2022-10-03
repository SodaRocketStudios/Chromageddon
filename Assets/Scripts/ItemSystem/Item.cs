using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;

namespace SRS.ItemSystem
{
	[CreateAssetMenu(fileName = "New Item", menuName = "Item System/Item")]
	public class Item : ScriptableObject
	{
		[SerializeField]
		private List<ItemData> data = new List<ItemData>();

		public void Apply(CharacterData character)
		{
			foreach(ItemData itemData in data)
			{
				if(character.CharacterStats.ContainsKey(itemData.stat))
				{
					switch(itemData.modifier)
					{
						case ModifierType.Additive:
							character.CharacterStats[itemData.stat].AdditiveModifier += itemData.intensity;
							break;
						case ModifierType.Multiplicative:
							character.CharacterStats[itemData.stat].MultiplicativeModifier += itemData.intensity;
							break;
						case ModifierType.Flat:
							character.CharacterStats[itemData.stat].FlatModifier += itemData.intensity;
							break;
						default:
							break;
					}
				}
				else if(character.AttackStats.ContainsKey(itemData.stat))
				{
					switch(itemData.modifier)
					{
						case ModifierType.Additive:
							character.AttackStats[itemData.stat].AdditiveModifier += itemData.intensity;
							break;
						case ModifierType.Multiplicative:
							character.AttackStats[itemData.stat].MultiplicativeModifier += itemData.intensity;
							break;
						case ModifierType.Flat:
							character.AttackStats[itemData.stat].FlatModifier += itemData.intensity;
							break;
						default:
							break;
					}
				}
			}
		}

		public void Remove(CharacterData character)
		{
			foreach(ItemData itemData in data)
			{
				if(character.CharacterStats.ContainsKey(itemData.stat))
				{
					switch(itemData.modifier)
					{
						case ModifierType.Additive:
							character.CharacterStats[itemData.stat].AdditiveModifier -= itemData.intensity;
							break;
						case ModifierType.Multiplicative:
							character.CharacterStats[itemData.stat].MultiplicativeModifier -= itemData.intensity;
							break;
						case ModifierType.Flat:
							character.CharacterStats[itemData.stat].FlatModifier -= itemData.intensity;
							break;
						default:
							break;
					}
				}
				else if(character.AttackStats.ContainsKey(itemData.stat))
				{
					switch(itemData.modifier)
					{
						case ModifierType.Additive:
							character.AttackStats[itemData.stat].AdditiveModifier -= itemData.intensity;
							break;
						case ModifierType.Multiplicative:
							character.AttackStats[itemData.stat].MultiplicativeModifier -= itemData.intensity;
							break;
						case ModifierType.Flat:
							character.AttackStats[itemData.stat].FlatModifier -= itemData.intensity;
							break;
						default:
							break;
					}
				}
			}
		}
	}
}