using UnityEngine;

namespace SRS.Stats
{
    [CreateAssetMenu(fileName = "New Percentage Modifier", menuName = "Stats/Modifiers/Precentage Modifier")]
    public class PercentageModifier : StatModifier
    {
        public override void Apply(StatContainer container)
        {
            container[affectedStat].PercentageModifier += value;
        }

        public override void Remove(StatContainer container)
        {
            container[affectedStat].PercentageModifier -= value;
        }
    }
}
