using UnityEngine;

namespace SRS.Stats
{
    [CreateAssetMenu(fileName = "New Multiplier Modifier", menuName = "Stats/Modifiers/Multiplier Modifier")]
    public class MultiplierModifier : StatModifier
    {
        public override void Apply(StatContainer container)
        {
            if(value > 0)
            {
                container[affectedStat].PercentageModifier *= value;
            }
            else
            {
                container[affectedStat].SetZero();
            }
        }

        public override void Remove(StatContainer container)
        {
            if(value > 0)
            {
                container[affectedStat].PercentageModifier /= value;
            }
            else
            {
                container[affectedStat].RemoveZero();
            }
        }
    }
}
