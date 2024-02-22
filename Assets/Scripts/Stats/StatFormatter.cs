namespace SRS.Stats
{
	public static class StatFormatter
	{
		public static string GetStat(Stat stat)
		{
			switch(stat.Format)
			{
				case StatFormat.Full:
					return $"Current {stat.Name}: {stat.BaseValue:N0} x {stat.PercentageModifier:N0}% = {stat.Value}";
				case StatFormat.BaseValue:
					return $"Current {stat.Name}: {stat.BaseValue:N2}";
				case StatFormat.Percentage:
					return $"Current {stat.Name}: {stat.PercentageModifier:N0}%";
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