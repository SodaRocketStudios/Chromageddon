using UnityEngine;
using System.Collections.Generic;

namespace SRS.StatSystem
{
	public class CharacterStats : MonoBehaviour
	{
		[SerializeField] private BaseCharacterStats baseData;

		public Dictionary<string, Stat> Character = new Dictionary<string, Stat>();
		public Dictionary<string, Stat> Attack = new Dictionary<string, Stat>();

		private void Awake()
		{
			InitializeStats();
		}

		private void InitializeStats()
		{
			foreach(Stat stat in baseData.CharacterStats)
			{
				Character[stat.Name] = new Stat(stat);
			}
			
			foreach(Stat stat in baseData.AttackStats)
			{
				Attack[stat.Name] = new Stat(stat);
			}
		}
	}

	public enum ModifierType
	{
		Additive,
		Multiplicative,
		Flat
	}
}