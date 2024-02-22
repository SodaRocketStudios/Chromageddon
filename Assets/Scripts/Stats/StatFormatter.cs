namespace SRS.Stats
{
	public static class StatFormatter
	{
		public static string GetStat(Stat stat)
		{
			switch(stat.Format)
			{
				case StatFormat.Full:
					return $"{stat.Name}: {stat.BaseValue:N1} x {stat.PercentageModifier:N0}% = {stat.Value}";
				case StatFormat.BaseValue:
					return $"{stat.Name}: {stat.BaseValue:N1}";
				case StatFormat.Percentage:
					return $"{stat.Name}: {stat.PercentageModifier:N0}%";
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