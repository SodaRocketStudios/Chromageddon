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
					return $"{statName}: {stat.BaseValue:0.0} x {stat.PercentageModifier*100:I} = {stat.Value}";
				case StatFormat.BaseValue:
					return $"{statName}: {stat.BaseValue:0.0}";
				case StatFormat.Percentage:
					return $"{statName}: {stat.PercentageModifier*100:I}";
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