using UnityEngine;

namespace SRS.Stats
{
    [CreateAssetMenu(fileName = "New Initial Base Modifier", menuName = "Stat Modifiers/Initial Base Modifier")]
    public class InitialBaseValue: StatModifier
    {
		private float oldValue;
        public override void Apply(StatContainer container)
        {
			oldValue = container[affectedStat].BaseValue;
            container[affectedStat].BaseValue = value;
        }

        public override void Remove(StatContainer container)
        {
            container[affectedStat].BaseValue = oldValue;
        }
    }
}
