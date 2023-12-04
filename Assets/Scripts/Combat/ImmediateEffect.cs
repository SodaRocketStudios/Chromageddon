using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
    public abstract class ImmediateEffect : IOnHitEffect
    {
        [SerializeField] private string procStat;

        public string ProcStat => procStat;

        public void Trigger(GameObject target)
        {
            OnTrigger(target);
        }

		protected abstract void OnTrigger(GameObject target);
    }
}