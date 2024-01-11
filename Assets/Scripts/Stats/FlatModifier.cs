using UnityEngine;

namespace SRS.Stats
{
    [CreateAssetMenu(fileName = "New Flat Modifier", menuName = "Stats/Modifiers/Flat Modifier")]
    public class FlatModifier : StatModifier
    {
        public override void Apply(StatContainer container)
        {
            container[affectedStat].BaseValue += value;
        }

        public override void Remove(StatContainer container)
        {
            container[affectedStat].BaseValue -= value;
        }
    }
}
