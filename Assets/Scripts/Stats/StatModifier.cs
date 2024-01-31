using UnityEngine;

namespace SRS.Stats
{
    public abstract class StatModifier: ScriptableObject
    {
        [SerializeField] protected string affectedStat;
        public string AffectedStat
        {
            get => affectedStat;
        }

        [SerializeField] protected float value;
        public float Value
        {
            get => value;
        }

        public abstract void Apply(StatContainer container);

        public abstract void Remove(StatContainer container);
    }
}
