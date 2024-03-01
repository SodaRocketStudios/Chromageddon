using UnityEngine;

namespace SRS.Stats
{
    [CreateAssetMenu(fileName = "New Multiplier Modifier", menuName = "Stat Modifiers/Multiplier Modifier")]
    public class MultiplierModifier : StatModifier
    {
        public override void Apply(StatContainer container)
        {
            if(value != 0)
            {
                if(container[affectedStat].Format == StatFormat.Percentage)
                {
                    container[affectedStat].PercentageModifier *= value;
                    return;
                }

                container[affectedStat].BaseValue *= value;
            }
            else
            {
                container[affectedStat].SetZero();
            }
        }

        public override void Remove(StatContainer container)
        {
            if(value != 0)
            {
                if(container[affectedStat].Format == StatFormat.Percentage)
                {
                    container[affectedStat].PercentageModifier /= value;
                    return;
                }

                container[affectedStat].BaseValue /= value;
            }
            else
            {
                container[affectedStat].RemoveZero();
            }
        }

        protected override string GetUnitSymbol()
        {
            return "";
        }
    }
}
