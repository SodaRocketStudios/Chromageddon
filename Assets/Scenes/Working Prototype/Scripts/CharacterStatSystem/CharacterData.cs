using UnityEngine;
using System.Collections.Generic;

namespace SRS.Stats
{
	public class CharacterData : MonoBehaviour
	{
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
				Debug.Log(stat.Name);
			}

			// CharacterStats = new Dictionary<string, Stat>(baseData.CharacterStats);
			// AttackStats = new Dictionary<string, Stat>(baseData.AttackStats);
		}
	}
}