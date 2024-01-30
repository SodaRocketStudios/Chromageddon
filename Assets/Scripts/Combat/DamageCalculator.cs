using SRS.Stats;
using SRS.Utils.Curves;

namespace SRS.Combat
{
	public static class DamageCalculator
	{
		private static SigmoidCurve armorCurve = new(2, 0, 1, .01f);

		public static float Calculate(float amount, StatContainer defenderStats, DamageType damageType)
		{
			switch(damageType)
			{
				case DamageType.Physical:
					amount *= 1 - armorCurve.Evaluate(defenderStats["Armor"].Value);
					break;

				case DamageType.Fire:
					amount *= 1 - defenderStats["Fire Resistance"].Value;
					break;

				case DamageType.Ice:
					amount *= 1 - defenderStats["Ice Resistance"].Value;
					break;

				case DamageType.Electric:
					amount *= 1 - defenderStats["Electric Resistance"].Value;
					break;

				default:
					break;
			}
			
			return amount;
		}
	}
}
