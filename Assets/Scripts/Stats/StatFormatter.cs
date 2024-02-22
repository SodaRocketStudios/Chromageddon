namespace SRS.Stats
{
	public static class StatFormatter
	{
		public static string GetStat(StatContainer stats, string statName)
		{
			string statData;

			Stat stat = stats[statName];

			switch(stat.Format)
			{
				case StatFormat.Full:
					statData = $"{statName}: {stat.BaseValue:0.0} x {stat.PercentageModifier*100:I} = {stat.Value}";
					break;
				case StatFormat.BaseValue:
					statData = $"";
					break;
				case StatFormat.Percentage:
					statData = $"";
					break;
				default:
					statData = "No format set";
					break;
			}

			return statData;
		}
	}

	public enum StatFormat
	{
		Full,
		BaseValue,
		Percentage
	}
}