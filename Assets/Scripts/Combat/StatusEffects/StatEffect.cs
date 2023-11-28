using UnityEngine;
using SRS.Stats;

namespace SRS.Combat.StatusEffects
{
    public class StatEffect : IEffect
    {
        [SerializeField] private StatModifier statModifier;

        public void Apply(StatContainer targetStats)
        {
            statModifier.Apply(targetStats);
        }

        public void Remove(StatContainer targetStats)
        {
            statModifier.Remove(targetStats);
        }
    }
}
