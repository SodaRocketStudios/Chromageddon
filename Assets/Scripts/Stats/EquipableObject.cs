using System.Collections.Generic;
using UnityEngine;

namespace SRS.Stats
{
    public abstract class EquipableObject: ScriptableObject
    {
        [SerializeField] private new string name;
        public string Name
        {
            get => name;
        }

        [SerializeField] private Sprite sprite;
        public Sprite Sprite
        {
            get => sprite;
        }

        [SerializeField] private List<StatModifier> modifiers;

        [SerializeField] private string description;

        public void Equip(StatContainer container)
        {
            foreach(StatModifier modifier in modifiers)
            {
                modifier.Apply(container);
            }
            
            OnEquip(container);
        }

        public void Unequip(StatContainer container)
        {
            foreach(StatModifier modifier in modifiers)
            {
                modifier.Remove(container);
            }

            OnUnequip(container);
        }

        protected abstract void OnEquip(StatContainer container);
        protected abstract void OnUnequip(StatContainer container);

        public string GetFormattedDescription()
        {
            return "";
        }
    }
}