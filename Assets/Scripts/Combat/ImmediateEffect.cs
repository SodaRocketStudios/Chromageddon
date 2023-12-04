using UnityEngine;

namespace SRS.Combat
{
    public abstract class ImmediateEffect : IOnHitEffect
    {
        public void Trigger(GameObject stats)
        {
            
        }

		protected abstract void OnTrigger(GameObject Stats);
    }
}