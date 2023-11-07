using SRS.Stats;

namespace SRS.Combat
{
	public static class DamageCalculator
	{
		public static float Calculate(StatContainer attackerStats, StatContainer defenderStats, DamageType damageType)
		{
			return attackerStats["Damage"].Value;
		}
	}
}
