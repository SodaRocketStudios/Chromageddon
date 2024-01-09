using SRS.Stats;
using UnityEngine;

namespace SRS.Combat.HitEffects
{
    public class StatEffect : Effect
    {
		[SerializeField] private StatModifier statModifier;

        public override void Apply(GameObject target)
        {
            // TODO -- start timer to remove modifier when complete
			statModifier.Apply(target.GetComponent<StatContainer>());
        }

		public void Remove(GameObject target)
		{
			statModifier.Remove(target.GetComponent<StatContainer>());
		}
    }
}