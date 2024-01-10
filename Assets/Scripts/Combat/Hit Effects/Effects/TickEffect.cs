using UnityEngine;

namespace SRS.Combat.HitEffects
{
    [CreateAssetMenu(fileName = "New Tick Effect", menuName = "Combat/Hit Effects/Effects/Tick Effect")]
    public class TickEffect : LastingEffect
    {
        [SerializeField] private float tickDelay;
        public float TickDelay
        {
            get => tickDelay;
        }

        private TickBehavior behavior;

        public override void Apply(GameObject target)
        {
            EffectTracker tracker = target.GetComponent<EffectTracker>();

            if(tracker != null)
            {
                tracker.AddEffect(this);
            }
        }

		public override void Remove(GameObject target)
		{
		}

        public void Tick()
        {
            if(behavior != null)
            {
                behavior.Tick();
            }
        }
    }
}