using System.Text;

namespace SRS.Stats
{
	public static class StatFormatter
	{
		public static string GetStat(Stat stat)
		{
			StringBuilder descriptionBuilder = new();

			string maxValueFormat = "0.#";

			switch(stat.Format)
			{
				case StatFormat.Flat:
					descriptionBuilder.Append($"Current {stat.Name}: {stat.BaseValue:0.#}");
					break;
				case StatFormat.Percentage:
					descriptionBuilder.Append($"Current {stat.Name}: {stat.PercentageModifier:P0}");
					maxValueFormat = "P0";
					break;
				case StatFormat.Full:
					descriptionBuilder.Append($"Current {stat.Name}: {stat.BaseValue:0.#} x {stat.PercentageModifier:P0} = {stat.ValueUnclamped:0.#}");
					break;
				default:
					return $"No definition for format type {stat.Format}.";
			}

			if(stat.HasMaximum)
			{
				string.Format(maxValueFormat, stat.MaximumValue);
				descriptionBuilder.AppendLine($"\nMax: {stat.MaximumValue.ToString(maxValueFormat)}");
			}

			return descriptionBuilder.ToString();
		}
	}
}