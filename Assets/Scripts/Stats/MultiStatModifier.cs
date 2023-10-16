using System.Collections.Generic;
using UnityEngine;

namespace SRS.Stats
{
    public abstract class MultiStatModifier: ScriptableObject
    {
        [SerializeField] protected string name;

        [SerializeField] private List<StatModifier> modifiers;

        [SerializeField] private string description;

        public void Apply(StatContainer container)
        {
            foreach(StatModifier modifier in modifiers)
            {
                modifier.Apply(container);
            }
        }

        public void Remove(StatContainer container)
        {
            foreach(StatModifier modifier in modifiers)
            {
                modifier.Remove(container);
            }
        }

        public string GetFormattedDescription()
        {
            return "";
        }
    }
}
