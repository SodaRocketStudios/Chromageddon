using UnityEngine;
using SRS.Stats;

namespace SRS.Combat.StatusEffects
{
    public class StatEffect : Effect
    {
        [SerializeField] private StatModifier statModifier;

        public void Apply(GameObject target)
        {
            statModifier.Apply(target.GetComponent<StatContainer>());
        }

        public void Remove(GameObject target)
        {
            statModifier.Remove(target.GetComponent<StatContainer>());
        }
    }
}
