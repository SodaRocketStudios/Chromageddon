using UnityEngine;

namespace SRS.Combat.HitEffects
{
    [CreateAssetMenu(fileName = "New Instant Damage Effect", menuName = "Combat/Hit Effects/Effects/Instant Damage Effect")]
    public class ExplosionEffect : Effect
    {
        public override void Apply(GameObject source, GameObject target)
        {
			// TODO -- Overlap circle hit all
        }
    }
}