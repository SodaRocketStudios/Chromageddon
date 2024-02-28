using System.Diagnostics;
using UnityEngine;

namespace SRS.Combat.HitEffects
{
	[CreateAssetMenu(fileName = "New Instant Damage Effect", menuName = "Combat/Hit Effects/Effects/Instant Damage Effect")]
    public class InstantDamageEffect : Effect
    {
		[SerializeField] private float damage;

		[SerializeField] private DamageType damageType;

        public override void Apply(GameObject source, GameObject target)
        {
            HitHandler hitHandler;

			if(target.TryGetComponent(out hitHandler))
			{
				hitHandler.Hit(damage, damageType);
			}
        }
    }
}