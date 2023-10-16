using UnityEngine;
using SRS.Health;

namespace SRS.StatusEffects
{
	[CreateAssetMenu(fileName = "New Damge Over time Effect", menuName = "Status Effect/Damage Over Time Effect")]
    public class DamageOverTimeEffect : TickEffect
    {
        private HealthManager targetHealth;

        protected override void Initialize(GameObject target)
        {
            targetHealth = target.GetComponent<HealthManager>();
        }

        protected override void HandleTick()
        {
            if(targetHealth != null)
            {
			    targetHealth.Damage(intensity);
            }
        }
    }
}