using UnityEngine;

namespace SRS.Stats
{
    public class InitialPercentageModifier : StatModifier
    {
		private float oldValue;

        public override void Apply(StatContainer container)
        {
			oldValue = container[affectedStat].PercentageModifier;
			container[affectedStat].PercentageModifier = value;
        }

        public override void Remove(StatContainer container)
        {
            container[affectedStat].PercentageModifier = oldValue;
        }
    }
}
