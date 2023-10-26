using System.Collections.Generic;
using UnityEngine;

namespace SRS.Stats
{
    public class StatContainer : MonoBehaviour
    {
        private Dictionary<string, Stat> stats = new();

        public Stat this[string stat]
        {
            get
            {
                return stats[stat];
            }
        }

        private bool initialized = false;

        private void Start()
        {
            if(!initialized)
            {
                Initialize();
            }
        }

        public void AddInitialModifiers(EquipableData modifiers)
        {
            if(!initialized)
            {
                Initialize();
            }

            modifiers.Apply(this);
        }

        public void RemoveInitialModifiers(EquipableData modifiers)
        {
            modifiers.Remove(this);
        }

        public void ResetStats()
        {
            stats.Clear();

            Initialize();
        }

        private void Initialize()
        {
            foreach(Stat stat in StatDatabase.Stats.Values)
            {
                stats[stat.Name] = stat.DeepCopy();
            }

            initialized = true;
        }
    }
}