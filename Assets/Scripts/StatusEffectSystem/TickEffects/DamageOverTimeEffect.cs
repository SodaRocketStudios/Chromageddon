using UnityEngine;

namespace SRS.StatusEffects
{
	[CreateAssetMenu(fileName = "New Damge Over time Effect", menuName = "Damage Over Time Effect")]
    public class DamageOverTimeEffect : TickEffect
    {
        public override void Apply(GameObject target)
        {

        }

        public override void Remove()
        {

        }

        protected override void HandleTick()
        {
			targetHealth.Damage(intensity);
        }
    }
}