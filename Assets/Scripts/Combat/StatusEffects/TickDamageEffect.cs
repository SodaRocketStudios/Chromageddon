using UnityEngine;

namespace SRS.Combat.StatusEffects
{
    public class TickDamageEffect : Effect
    {
		[SerializeField] private float intensity;

        [SerializeField] private DamageType damageType;

        public void Tick(GameObject target)
        {
            target.GetComponent<HitHandler>().Hit(intensity, damageType);
        }
    }
}