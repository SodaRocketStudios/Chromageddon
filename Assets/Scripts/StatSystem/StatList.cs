using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatSystem
{
	[CreateAssetMenu(fileName = "New Stat List", menuName = "Character Data/Stat List")]
	public class StatList : ScriptableObject
	{
		public List<string> stats;
	}
}