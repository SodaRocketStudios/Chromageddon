using UnityEngine;
using SRS.StatSystem;

namespace SRS.ItemSystem
{
	[System.Serializable]
	public class ItemEffect
	{
		[SerializeField] private string statName;

		[SerializeField] private StatModifier modifier;

		public void Apply(CharacterData data)
		{
			data.Stats[statName]?.AddModifier(modifier);
		}

		public void Remove(CharacterData data)
		{
			data.Stats[statName]?.RemoveModifier(modifier);
		}
	}
}