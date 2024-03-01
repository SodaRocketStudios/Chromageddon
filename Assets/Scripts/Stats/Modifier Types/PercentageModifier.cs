using UnityEngine;

namespace SRS.Stats
{
    [CreateAssetMenu(fileName = "New Percentage Modifier", menuName = "Stat Modifiers/Precentage Modifier")]
    public class PercentageModifier : StatModifier
    {
        public override void Apply(StatContainer container)
        {
            if(container[affectedStat].Format == StatFormat.Flat)
            {
                container[affectedStat].BaseValue *= (100 - value)/100;
            }

            container[affectedStat].PercentageModifier += value/100;
        }

        public override void Remove(StatContainer container)
        {
            if(container[affectedStat].Format == StatFormat.Flat)
            {
                container[affectedStat].BaseValue /= (100 - value)/100;
            }

            container[affectedStat].PercentageModifier -= value/100;
        }

        protected override string GetUnitSymbol()
        {
            return "%";
        }
    }
}