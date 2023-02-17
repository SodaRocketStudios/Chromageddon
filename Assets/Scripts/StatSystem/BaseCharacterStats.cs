using UnityEngine;
using System.Collections.Generic;
using SRS.DataReader;

namespace SRS.StatSystem
{
	[CreateAssetMenu(fileName = "New Base Character Data", menuName = "Character Data/Character Base Data")]
	public class BaseCharacterStats : ScriptableObject
	{
		[SerializeField] private string characterStatFile;
		public List<Stat> CharacterStats = new List<Stat>();

		[SerializeField] private string attackStatFile;
		public List<Stat> AttackStats = new List<Stat>();

		// private void Awake()
		// {
		// 	PopulateStats();
		// }

		public void PopulateStats(string _characterStatFile, string _attackStatFile)
		{
			characterStatFile = _characterStatFile;
			attackStatFile = _attackStatFile;

			PopulateStats();
		}

		public void PopulateStats()
		{
			Dictionary<string, Stat> stats = new Dictionary<string, Stat>();

			List<Dictionary<string, object>> characterStats = CSVReader.Read(characterStatFile);

			CharacterStats.Clear();

			foreach(Dictionary<string, object> stat in characterStats)
			{
				string statName = stat["Name"].ToString();
				float baseValue = float.Parse(stat["Base Value"].ToString());
				float additive = float.Parse(stat["Additive Modifier"].ToString());
				float multiplicative = float.Parse(stat["Multiplicative Modifier"].ToString());
				float flat = float.Parse(stat["Flat Modifier"].ToString());

				Stat newStat = new Stat(statName, baseValue, additive, multiplicative, flat);

				CharacterStats.Add(newStat);
			}

			List<Dictionary<string, object>> attackStats = CSVReader.Read(attackStatFile);

			AttackStats.Clear();

			foreach(Dictionary<string, object> stat in attackStats)
			{
				string statName = stat["Name"].ToString();
				float baseValue = float.Parse(stat["Base Value"].ToString());
				float additive = float.Parse(stat["Additive Modifier"].ToString());
				float multiplicative = float.Parse(stat["Multiplicative Modifier"].ToString());
				float flat = float.Parse(stat["Flat Modifier"].ToString());

				Stat newStat = new Stat(statName, baseValue, additive, multiplicative, flat);

				AttackStats.Add(newStat);
			}
		}
	}
}