namespace SRS.Stats
{
	public static class StatFormatter
	{
		public static string GetStat(StatContainer stats, string statName)
		{
			Stat stat = stats[statName];

			switch(stat.Format)
			{
				case StatFormat.Full:
					return $"{statName}: {stat.BaseValue:N1} x {stat.PercentageModifier:P} = {stat.Value}";
				case StatFormat.BaseValue:
					return $"{statName}: {stat.BaseValue:N1}";
				case StatFormat.Percentage:
					return $"{statName}: {stat.PercentageModifier:P}";
				default:
					return "No format set";
			}
		}
	}

	public enum StatFormat
	{
		Full,
		BaseValue,
		Percentage
	}
}