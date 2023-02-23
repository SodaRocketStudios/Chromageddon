using UnityEngine;

namespace SRS.StatusEffects
{
	[CreateAssetMenu(fileName = "New Damge Over time Effect", menuName = "Damage Over Time Effect")]
    public class DamageOverTimeEffect : TickEffect
    {
        protected override void HandleTick()
        {
			targetHealth.Damage(intensity);
        }
    }
}