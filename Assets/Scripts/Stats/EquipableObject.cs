using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

namespace SRS.Stats
{
    public abstract class EquipableObject: ScriptableObject
    {
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

        public List<string> AffectedStats
        {
            get
            {
                List<string> stats = new();
                foreach(StatModifier modifier in modifiers)
                {
                    stats.Add(modifier.AffectedStat);
                }
                return stats;
            }
        }

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

        public string BuildDescription()
        {
            StringBuilder descriptionBuilder = new();

            foreach(StatModifier modifier in modifiers)
            {
                descriptionBuilder.AppendLine(modifier.Description);
            }

            return descriptionBuilder.ToString();
        }

        public string BuildDescription(StatContainer stats)
        {
            StringBuilder descriptionBuilder = new();

            foreach(StatModifier modifier in modifiers)
            {
                descriptionBuilder.AppendLine(modifier.BuildRelativeDescription(stats));
            }

            return descriptionBuilder.ToString();
        }
    }
}