using UnityEngine;
using System.Collections.Generic;

namespace SRS.Stats
{
	[CreateAssetMenu(fileName = "New Character Stats", menuName = "Character Data/Character Data Object")]
	public class CharacterDataObject : ScriptableObject
	{
		public Dictionary<string, Stat> CharacterStats = new Dictionary<string, Stat>();
		public Dictionary<string, Stat> AttackStats = new Dictionary<string, Stat>();
	}
}