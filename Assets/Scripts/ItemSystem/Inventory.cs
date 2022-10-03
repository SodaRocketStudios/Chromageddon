using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;

namespace SRS.ItemSystem
{
	public class Inventory : MonoBehaviour
	{
		private List<Item> items = new List<Item>();

		private CharacterData characterData;

		private void Awake()
		{
			characterData = GetComponent<CharacterData>();
		}

		public void AddItem(Item item)
		{
			items.Add(item);

			foreach(ItemEffectData effect in item.Data)
			{
				AddEffect(effect);
			}
		}

		public void RemoveItem(Item item)
		{
			foreach(ItemEffectData effect in item.Data)
			{
				RemoveEffect(effect);
			}
		}

		private void AddEffect(ItemEffectData effect)
		{
			if(characterData.CharacterStats.ContainsKey(effect.stat))
			{
				switch(effect.modifier)
				{
					case ModifierType.Additive:
						characterData.CharacterStats[effect.stat].AdditiveModifier += effect.intensity;
						break;
					case ModifierType.Multiplicative:
						characterData.CharacterStats[effect.stat].MultiplicativeModifier += effect.intensity;
						break;
					case ModifierType.Flat:
						characterData.CharacterStats[effect.stat].FlatModifier += effect.intensity;
						break;
					default:
						break;
				}
			}
			else if(characterData.AttackStats.ContainsKey(effect.stat))
			{
				switch(effect.modifier)
				{
					case ModifierType.Additive:
						characterData.AttackStats[effect.stat].AdditiveModifier += effect.intensity;
						break;
					case ModifierType.Multiplicative:
						characterData.AttackStats[effect.stat].MultiplicativeModifier += effect.intensity;
						break;
					case ModifierType.Flat:
						characterData.AttackStats[effect.stat].FlatModifier += effect.intensity;
						break;
					default:
						break;
				}
			}
		}

		private void RemoveEffect(ItemEffectData effect)
		{
			if(characterData.CharacterStats.ContainsKey(effect.stat))
			{
				switch(effect.modifier)
				{
					case ModifierType.Additive:
						characterData.CharacterStats[effect.stat].AdditiveModifier -= effect.intensity;
						break;
					case ModifierType.Multiplicative:
						characterData.CharacterStats[effect.stat].MultiplicativeModifier -= effect.intensity;
						break;
					case ModifierType.Flat:
						characterData.CharacterStats[effect.stat].FlatModifier -= effect.intensity;
						break;
					default:
						break;
				}
			}
			else if(characterData.AttackStats.ContainsKey(effect.stat))
			{
				switch(effect.modifier)
				{
					case ModifierType.Additive:
						characterData.AttackStats[effect.stat].AdditiveModifier -= effect.intensity;
						break;
					case ModifierType.Multiplicative:
						characterData.AttackStats[effect.stat].MultiplicativeModifier -= effect.intensity;
						break;
					case ModifierType.Flat:
						characterData.AttackStats[effect.stat].FlatModifier -= effect.intensity;
						break;
					default:
						break;
				}
			}
		}
	}
}