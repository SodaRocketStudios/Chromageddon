using UnityEngine;
using SRS.Stats;

namespace SRS.Combat.StatusEffects
{
    public class StatEffect : Effect
    {
        [SerializeField] private StatModifier statModifier;

        public StatEffect(Effect effect) : base(effect)
        {
        }

        protected override void OnApply()
        {
            statModifier.Apply(targetStats);
        }

        private void OnDestroy()
        {
            statModifier.Remove(targetStats);
        }
    }
}
