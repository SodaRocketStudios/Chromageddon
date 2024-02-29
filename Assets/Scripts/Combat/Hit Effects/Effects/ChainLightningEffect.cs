using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.Combat.HitEffects
{
	[CreateAssetMenu(fileName = "New Chain Lightning Effect", menuName = "Combat/Hit Effects/Effects/Chain Lightning Effect")]
    public class ChainLightningEffect : Effect
    {
		[SerializeField] private AttackData attackData;

		[SerializeField] private ObjectPool attackPool;

        public override void Apply(GameObject source, GameObject target)
        {
			Attack attack = attackPool.Get(target.transform.position) as Attack;

            attack.Initialize(attackData, source, target.transform);
        }
    }
}