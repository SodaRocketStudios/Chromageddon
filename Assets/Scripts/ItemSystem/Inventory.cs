using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;

namespace SRS.ItemSystem
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField]
		private List<Item> starterItems;
		private List<Item> items = new List<Item>();

		private CharacterData characterData;

		private void Awake()
		{
			characterData = GetComponent<CharacterData>();
		}

		private void Start()
		{
			AddStarterItems();
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
			// TO DO - Remove item from the item list.

			foreach(ItemEffectData effect in item.Data)
			{
				RemoveEffect(effect);
			}
		}

		private void AddEffect(ItemEffectData effect)
		{
			if(characterData.CharacterStats.ContainsKey(effect.Stat))
			{
				switch(effect.Modifier)
				{
					case ModifierType.Additive:
						characterData.CharacterStats[effect.Stat].AdditiveModifier += effect.Intensity;
						break;
					case ModifierType.Multiplicative:
						characterData.CharacterStats[effect.Stat].MultiplicativeModifier += effect.Intensity;
						break;
					case ModifierType.Flat:
						characterData.CharacterStats[effect.Stat].FlatModifier += effect.Intensity;
						break;
					default:
						break;
				}
				Debug.Log($"{effect.Stat}: {characterData.CharacterStats[effect.Stat].Value}");
			}
			else if(characterData.AttackStats.ContainsKey(effect.Stat))
			{
				switch(effect.Modifier)
				{
					case ModifierType.Additive:
						characterData.AttackStats[effect.Stat].AdditiveModifier += effect.Intensity;
						break;
					case ModifierType.Multiplicative:
						characterData.AttackStats[effect.Stat].MultiplicativeModifier += effect.Intensity;
						break;
					case ModifierType.Flat:
						characterData.AttackStats[effect.Stat].FlatModifier += effect.Intensity;
						break;
					default:
						break;
				}
				Debug.Log($"{effect.Stat}: {characterData.AttackStats[effect.Stat].Value}");
			}
		}

		private void RemoveEffect(ItemEffectData effect)
		{
			if(characterData.CharacterStats.ContainsKey(effect.Stat))
			{
				switch(effect.Modifier)
				{
					case ModifierType.Additive:
						characterData.CharacterStats[effect.Stat].AdditiveModifier -= effect.Intensity;
						break;
					case ModifierType.Multiplicative:
						characterData.CharacterStats[effect.Stat].MultiplicativeModifier -= effect.Intensity;
						break;
					case ModifierType.Flat:
						characterData.CharacterStats[effect.Stat].FlatModifier -= effect.Intensity;
						break;
					default:
						break;
				}
			}
			else if(characterData.AttackStats.ContainsKey(effect.Stat))
			{
				switch(effect.Modifier)
				{
					case ModifierType.Additive:
						characterData.AttackStats[effect.Stat].AdditiveModifier -= effect.Intensity;
						break;
					case ModifierType.Multiplicative:
						characterData.AttackStats[effect.Stat].MultiplicativeModifier -= effect.Intensity;
						break;
					case ModifierType.Flat:
						characterData.AttackStats[effect.Stat].FlatModifier -= effect.Intensity;
						break;
					default:
						break;
				}
			}
		}

		private void AddStarterItems()
		{
			foreach(Item item in starterItems)
			{
				AddItem(item);
			}
		}
	}
}