using SRS.Combat.HitEffects;
using UnityEngine;

namespace SRS.Combat.StatusEffects
{
	public class LastingEffect : Effect
	{
		[SerializeField] private float duration;
		public float Duration
		{
			get => duration;
		}

        public override void Apply(GameObject target)
        {
            // TODO -- create and start an effect timer;
        }

		public void Remove(GameObject target)
		{
		}
    }
}