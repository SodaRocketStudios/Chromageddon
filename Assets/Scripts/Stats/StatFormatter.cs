namespace SRS.Stats
{
	public static class StatFormatter
	{
		public static string GetStat(StatContainer stats, string statName)
		{
			string stat;

			stat = $"{statName}: {stats[statName].BaseValue:0.#} x {stats[statName].PercentageModifier*100:I}";

			return stat;
		}
	}

	public enum StatFormat
	{
		Full,
		BaseValue,
		Percentage
	}
}