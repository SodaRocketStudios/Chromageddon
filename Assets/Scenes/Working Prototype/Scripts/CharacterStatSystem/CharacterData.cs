using UnityEngine;
using System.Collections.Generic;

namespace SRS.Stats
{
	public class CharacterData : MonoBehaviour
	{
		public Dictionary<string, Stat> CharacterStats = new Dictionary<string, Stat>();
		public Dictionary<string, Stat> AttackStats = new Dictionary<string, Stat>();

		private void Awake()
		{
			CharacterStats["MoveSpeed"] = new Stat("MoveSpeed", 5);
		}
	}
}