using System.Text;

namespace SRS.Stats
{
	public static class StatFormatter
	{
		public static string GetStat(Stat stat)
		{
			StringBuilder descriptionBuilder = new();

			string maxValueFormat = "N0";

			switch(stat.Format)
			{
				case StatFormat.Flat:
					descriptionBuilder.Append($"Current {stat.Name}: {stat.BaseValue:N0}");
					break;
				case StatFormat.Percentage:
					descriptionBuilder.Append($"Current {stat.Name}: {stat.PercentageModifier:P0}");
					maxValueFormat = "P0";
					break;
				case StatFormat.Full:
					descriptionBuilder.Append($"Current {stat.Name}: {stat.BaseValue:N0} x {stat.PercentageModifier:N0}% = {stat.ValueUnclamped}");
					break;
				default:
					return $"No definition for format type {stat.Format}.";
			}

			if(stat.HasMaximum)
			{
				string.Format(maxValueFormat, stat.MaximumValue);
				descriptionBuilder.AppendLine(string.Format("\nMax: {0}", stat.MaximumValue.ToString(maxValueFormat)));
				// descriptionBuilder.AppendLine($"\nMax: {string.Format("{0:maxValueFormat}", stat.MaximumValue)}");
			}

			return descriptionBuilder.ToString();
		}
	}
}