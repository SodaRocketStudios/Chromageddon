using UnityEngine;

namespace SRS.Combat.HitEffects
{
	[CreateAssetMenu(fileName = "New Instant Damage Effect", menuName = "Combat/Hit Effects/Effects/Instant Damage Effect")]
    public class ChainLightningEffect : Effect
    {
		[SerializeField] private float damage;

		[SerializeField] private AttackData attackData;

		private DamageType damageType = DamageType.Electric;

		private LayerMask collisionMask;

        public override void Apply(GameObject source, GameObject target)
        {
            HitHandler hitHandler;

			if(target.TryGetComponent(out hitHandler))
			{
				hitHandler.Hit(damage, damageType);
			}

			collisionMask = LayerMask.GetMask(LayerMask.LayerToName(target.layer));
        }
    }
}