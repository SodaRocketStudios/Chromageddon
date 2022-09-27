using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class TestPoisonEffect : StatusEffectBehavior
	{
		public TestPoisonEffect(float duration, List<EffectDataObject> data) : base(duration, data){}

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