using SRS.Stats;

namespace SRS.Combat
{
    public abstract class ImmediateEffect : IOnHitEffect
    {
        public void Trigger(StatContainer stats)
        {
            
        }

		protected abstract void OnTrigger(StatContainer Stats);
    }
}