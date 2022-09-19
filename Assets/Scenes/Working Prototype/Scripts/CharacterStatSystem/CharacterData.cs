using UnityEngine;
using System.Collections.Generic;
using SRS.DataReader;

namespace SRS.Stats
{
	public class CharacterData : MonoBehaviour
	{
		public string DataLocation = "Test.csv";
		public Dictionary<string, Stat> CharacterStats = new Dictionary<string, Stat>();
		public Dictionary<string, Stat> AttackStats = new Dictionary<string, Stat>();

		private void Awake()
		{
			Debug.Log(CSVReader.Read(DataLocation));
			CharacterStats["MoveSpeed"] = new Stat("MoveSpeed", 5);
		}
	}
}