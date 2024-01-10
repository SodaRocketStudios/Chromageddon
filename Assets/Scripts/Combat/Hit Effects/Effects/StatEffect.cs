using SRS.Stats;
using UnityEngine;

namespace SRS.Combat.HitEffects
{
    [CreateAssetMenu(fileName = "New Stat Effect", menuName = "Combat/Hit Effects/Effects/Stat Effect")]
    public class StatEffect : LastingEffect
    {
		[SerializeField] private StatModifier statModifier;

        public override void Apply(GameObject target)
        {
            StatContainer stats = target.GetComponent<StatContainer>();
            EffectTracker tracker = target.GetComponent<EffectTracker>();

            if(stats != null && tracker != null)
            {
                tracker.AddEffect(this);
			    statModifier.Apply(target.GetComponent<StatContainer>());
            }
        }

		public override void Remove(GameObject target)
		{
			statModifier.Remove(target.GetComponent<StatContainer>());
		}
    }
}