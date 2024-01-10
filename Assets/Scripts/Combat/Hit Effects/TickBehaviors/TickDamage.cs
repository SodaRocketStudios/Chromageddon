using UnityEngine;

namespace SRS.Combat.HitEffects
{
	[CreateAssetMenu(fileName = "New Tick Damage Behavior", menuName = "Combat/Hit Effects/Tick Behaviors/Tick Damage Behavior")]
    public class TickDamage : TickBehavior
    {
		[SerializeField] private float damage;

		[SerializeField] private DamageType damageType;

        public override void Tick(GameObject target)
        {
            target.GetComponent<HitHandler>().Hit(damage, damageType);
        }
    }
}