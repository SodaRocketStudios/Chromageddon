using UnityEngine;

namespace SRS.Combat.HitEffects
{
    [CreateAssetMenu(fileName = "New Tick Effect", menuName = "Combat/Hit Effects/Effects/Tick Effect")]
    public class TickEffect : LastingEffect
    {
        [SerializeField] private float tickDelay;

        private TickBehavior behavior;

        public override void Apply(GameObject target)
        {
            // TODO -- add a tick effect object to the target.
        }

		public override void Remove(GameObject target)
		{
			// TODO -- remove the tick effect object from the target.
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