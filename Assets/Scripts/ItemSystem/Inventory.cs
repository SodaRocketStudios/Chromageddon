using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;

namespace SRS.ItemSystem
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField]
		private List<Item> starterItems;
		private List<Item> items = new List<Item>();

		private CharacterStats characterStats;

		private void Awake()
		{
			characterStats = GetComponent<CharacterStats>();
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
			if(characterStats.Character.ContainsKey(effect.Stat))
			{
				switch(effect.Modifier)
				{
					case ModifierType.Additive:
						characterStats.Character[effect.Stat].AdditiveModifier += effect.Intensity;
						break;
					case ModifierType.Multiplicative:
						characterStats.Character[effect.Stat].MultiplicativeModifier += effect.Intensity;
						break;
					case ModifierType.Flat:
						characterStats.Character[effect.Stat].FlatModifier += effect.Intensity;
						break;
					default:
						break;
				}
			}
			else if(characterStats.Attack.ContainsKey(effect.Stat))
			{
				switch(effect.Modifier)
				{
					case ModifierType.Additive:
						characterStats.Attack[effect.Stat].AdditiveModifier += effect.Intensity;
						break;
					case ModifierType.Multiplicative:
						characterStats.Attack[effect.Stat].MultiplicativeModifier += effect.Intensity;
						break;
					case ModifierType.Flat:
						characterStats.Attack[effect.Stat].FlatModifier += effect.Intensity;
						break;
					default:
						break;
				}
			}
		}

		private void RemoveEffect(ItemEffectData effect)
		{
			if(characterStats.Character.ContainsKey(effect.Stat))
			{
				switch(effect.Modifier)
				{
					case ModifierType.Additive:
						characterStats.Character[effect.Stat].AdditiveModifier -= effect.Intensity;
						break;
					case ModifierType.Multiplicative:
						characterStats.Character[effect.Stat].MultiplicativeModifier -= effect.Intensity;
						break;
					case ModifierType.Flat:
						characterStats.Character[effect.Stat].FlatModifier -= effect.Intensity;
						break;
					default:
						break;
				}
			}
			else if(characterStats.Attack.ContainsKey(effect.Stat))
			{
				switch(effect.Modifier)
				{
					case ModifierType.Additive:
						characterStats.Attack[effect.Stat].AdditiveModifier -= effect.Intensity;
						break;
					case ModifierType.Multiplicative:
						characterStats.Attack[effect.Stat].MultiplicativeModifier -= effect.Intensity;
						break;
					case ModifierType.Flat:
						characterStats.Attack[effect.Stat].FlatModifier -= effect.Intensity;
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