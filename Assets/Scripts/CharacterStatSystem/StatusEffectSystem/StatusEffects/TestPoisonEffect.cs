using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class TestPoisonEffect : StatusEffectBehavior
	{
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