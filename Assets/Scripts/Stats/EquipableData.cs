using System.Collections.Generic;
using UnityEngine;

namespace SRS.Stats
{
    public abstract class EquipableData: ScriptableObject
    {
        [SerializeField] private new string name;

        [SerializeField] private Sprite sprite;

        [SerializeField] private List<StatModifier> modifiers;

        [SerializeField] private string description;

        public virtual void Equip(StatContainer container)
        {
            foreach(StatModifier modifier in modifiers)
            {
                modifier.Apply(container);
            }
        }

        public virtual void Remove(StatContainer container)
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
