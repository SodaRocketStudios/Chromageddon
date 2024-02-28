using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.Combat.HitEffects
{
	[CreateAssetMenu(fileName = "New Instant Damage Effect", menuName = "Combat/Hit Effects/Effects/Instant Damage Effect")]
    public class ChainLightningEffect : Effect
    {
		[SerializeField] private float damage;

		[SerializeField] private AttackData attackData;

		[SerializeField] private ObjectPool attackPool;

        public override void Apply(GameObject source, GameObject target)
        {
            HitHandler hitHandler;

			if(target.TryGetComponent(out hitHandler))
			{
				hitHandler.Hit(damage, attackData.DamageType);
			}

			Attack attack = attackPool.Get(source.transform.position, source.transform.rotation) as Attack;
            attack.Initialize(attackData, source);
        }
    }
}