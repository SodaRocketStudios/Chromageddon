using System;
using SRS.Extensions.Random;
using SRS.Stats;
using SRS.Utils.Curves;

namespace SRS.Combat
{
	public static class DamageCalculator
	{
		private static SigmoidCurve armorCurve = new(2, 0, 0, -0.01f);

		private static Random random = new(Guid.NewGuid().GetHashCode());

		public static float Calculate(float amount, StatContainer defenderStats, DamageType damageType)
		{
			switch(damageType)
			{
				case DamageType.Physical:
					amount *= armorCurve.Evaluate(defenderStats["Armor"].Value);
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
				
				case DamageType.Poison:
					amount *= 1 - defenderStats["Poison Resistance"].Value;
					break;

				default:
					break;
			}
			
			return amount;
		}

		public static bool CheckCritical(float critChance)
		{
			if(random.NextFloat() <= critChance)
			{
				return true;
			}

			return false;
		}

		public static bool CheckDodge(float dodgeChance)
		{
			if(random.NextFloat() <= dodgeChance)
			{
				return true;
			}

			return false;
		}
	}
}