using System.Collections.Generic;
using UnityEngine;

namespace SRS.Stats
{
    public abstract class EquipableData: ScriptableObject
    {
        [SerializeField] private string name;

        [SerializeField] private Sprite sprite;

        [SerializeField] private List<StatModifier> modifiers;

        [SerializeField] private string description;

        public void Equip(StatContainer container)
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
