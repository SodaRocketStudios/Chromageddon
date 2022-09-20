using UnityEngine;
using System.Collections.Generic;
using SRS.DataReader;

namespace SRS.Stats
{
	[CreateAssetMenu(fileName = "New Character Stats", menuName = "Character Data/Character Data Object")]
	public class BaseCharacterData : ScriptableObject
	{
		public Dictionary<string, Stat> CharacterStats = new Dictionary<string, Stat>();
		public Dictionary<string, Stat> AttackStats = new Dictionary<string, Stat>();

		private string characterStatFile;
		private string attackStatFile;

		public void PopulateStats(string characterStatFile, string attackStatFile)
		{
			Dictionary<string, Stat> stats = new Dictionary<string, Stat>();

			List<Dictionary<string, object>> characterStats = CSVReader.Read(characterStatFile);

			foreach(Dictionary<string, object> stat in characterStats)
			{
				string statName = stat["Name"].ToString();
				float baseValue = float.Parse(stat["Base Value"].ToString());
				float additive = float.Parse(stat["Additive Modifier"].ToString());
				float multiplicative = float.Parse(stat["Multiplicative Modifier"].ToString());
				float flat = float.Parse(stat["Flat Modifier"].ToString());

				Stat newStat = new Stat(statName, baseValue, additive, multiplicative, flat);

				CharacterStats[stat["Name"].ToString()] = newStat;
			}

			List<Dictionary<string, object>> attackStats = CSVReader.Read(attackStatFile);

			foreach(Dictionary<string, object> stat in attackStats)
			{
				string statName = stat["Name"].ToString();
				float baseValue = float.Parse(stat["Base Value"].ToString());
				float additive = float.Parse(stat["Additive Modifier"].ToString());
				float multiplicative = float.Parse(stat["Multiplicative Modifier"].ToString());
				float flat = float.Parse(stat["Flat Modifier"].ToString());

				Stat newStat = new Stat(statName, baseValue, additive, multiplicative, flat);

				AttackStats[stat["Name"].ToString()] = newStat;
			}
		}
	}
}