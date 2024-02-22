using UnityEngine;

namespace SRS.Stats
{
	public static class LogStat
	{
		public static void Log(string statName)
		{
			StatContainer stats = GameObject.FindWithTag("Player").GetComponent<StatContainer>();

			Debug.Log(StatFormatter.GetStat(stats, statName));
		}
	}
}