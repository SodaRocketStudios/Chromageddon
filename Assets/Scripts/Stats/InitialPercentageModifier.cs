using UnityEngine;

namespace SRS.Stats
{
    [CreateAssetMenu(fileName = "New Initial Percentage Modifier", menuName = "Stat Modifiers/Initial Precentage Modifier")]
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
