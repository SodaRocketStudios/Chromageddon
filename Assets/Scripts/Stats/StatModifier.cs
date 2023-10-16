using UnityEngine;

namespace SRS.Stats
{
    public abstract class StatModifier: ScriptableObject
    {
        [SerializeField] protected string affectedStat;

        [SerializeField] protected float value;

        [SerializeField] private string description;

        public abstract void Apply(StatContainer container);

        public abstract void Remove(StatContainer container);

        public string GetFormattedDescription()
        {
            return "";
        }
    }
}
