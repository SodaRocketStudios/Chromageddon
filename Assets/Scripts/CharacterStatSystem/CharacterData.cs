using UnityEngine;
using System.Collections.Generic;

namespace SRS.Stats
{
	public class CharacterData : MonoBehaviour
	{
		public delegate void UpdateStat();
		public event UpdateStat OnAttackStatChanged;
		public event UpdateStat OnCharacterStatChanged;

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
				CharacterStats[stat.Name] = stat;
				CharacterStats[stat.Name].OnValueChanged += OnCharacterStatChange;
			}
			
			foreach(Stat stat in baseData.AttackStats)
			{
				AttackStats[stat.Name] = stat;
				AttackStats[stat.Name].OnValueChanged += OnAttackStatChange;
			}
		}

		private void OnCharacterStatChange(float value)
		{
			OnCharacterStatChanged?.Invoke();
		}

		private void OnAttackStatChange(float value)
		{
			OnAttackStatChanged?.Invoke();
		}
	}
}