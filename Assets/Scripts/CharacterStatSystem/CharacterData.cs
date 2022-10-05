using UnityEngine;
using System.Collections.Generic;

namespace SRS.Stats
{
	public class CharacterData : MonoBehaviour
	{
		public delegate void UpdateStat();
		public event UpdateStat onAttackStatChanged;
		public event UpdateStat onCharacterStatChanged;

		public Dictionary<string, Stat> CharacterStats = new Dictionary<string, Stat>();
		public Dictionary<string, Stat> AttackStats = new Dictionary<string, Stat>();

		[SerializeField]
		private BaseCharacterData baseData;

		private void Awake()
		{
			InitializeStats();
		}

		private void InitializeStats()
		{
			foreach(Stat stat in baseData.CharacterStats)
			{
				Debug.Log($"{stat.Name}: {stat.Value}");
				CharacterStats[stat.Name] = stat;
				CharacterStats[stat.Name].onValueChanged += OnCharacterStatChange;
			}
			
			foreach(Stat stat in baseData.AttackStats)
			{
				Debug.Log($"{stat.Name}: {stat.Value}");
				AttackStats[stat.Name] = stat;
				AttackStats[stat.Name].onValueChanged += OnAttackStatChange;
			}
		}

		private void OnCharacterStatChange(float value)
		{
			onCharacterStatChanged?.Invoke();
		}

		private void OnAttackStatChange(float value)
		{
			onAttackStatChanged?.Invoke();
		}
	}

	public enum ModifierType
	{
		Additive,
		Multiplicative,
		Flat
	}
}