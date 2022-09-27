using System.Collections;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class TestPoisonEffect : StatusEffect
	{
        protected override float duration {get; set;} = 2;

		public TestPoisonEffect() : base(){}


        protected override IEnumerator EffectCoroutine()
		{
			// Apply slow

			while(Time.time < endTime)
			{
				// Ticking damage
			}

			// Remove slow

			yield return null;
		}
	}
}