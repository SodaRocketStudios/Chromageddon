using System.Text;

namespace SRS.Stats
{
	public static class StatFormatter
	{
		public static string GetStat(Stat stat)
		{
			StringBuilder descriptionBuilder = new();

			switch(stat.Format)
			{
				case StatFormat.Flat:
					descriptionBuilder.Append($"Current {stat.Name}: {stat.BaseValue:N2}");
					break;
				case StatFormat.Percentage:
					descriptionBuilder.Append($"Current {stat.Name}: {stat.PercentageModifier:N0}%");
					break;
				case StatFormat.Full:
					descriptionBuilder.Append($"Current {stat.Name}: {stat.BaseValue:N0} x {stat.PercentageModifier:N0}% = {stat.ValueUnclamped}");
					break;
				default:
					return $"No definition for format type {stat.Format}.";
			}

			if(stat.HasMaximum)
			{
				descriptionBuilder.AppendLine($"Max: {stat.MaximumValue}");
			}
			if(stat.HasMaximum)
			{
				descriptionBuilder.AppendLine($"Min: {stat.MinimumValue}");
			}

			return descriptionBuilder.ToString();
		}
	}
}