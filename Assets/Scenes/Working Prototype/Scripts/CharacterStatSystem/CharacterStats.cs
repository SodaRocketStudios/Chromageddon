using UnityEngine;
using System.Collections.Generic;

namespace SRS.Stats
{
	public class CharacterStats : ScriptableObject
	{
		public Dictionary<string, Stat> Stats = new Dictionary<string, Stat>();
	}
}