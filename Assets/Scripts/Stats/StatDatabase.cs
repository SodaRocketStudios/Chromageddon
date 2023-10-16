using System.Collections.Generic;
using UnityEngine;

namespace SRS.Stats
{
    public class StatDatabase : MonoBehaviour
    {
        [SerializeField] private List<Stat> stats = new();
        public static Dictionary<string, Stat> Stats = new();

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            foreach(Stat stat in stats)
            {
                Stats[stat.Name] = stat;
            }
        }
    }
}
