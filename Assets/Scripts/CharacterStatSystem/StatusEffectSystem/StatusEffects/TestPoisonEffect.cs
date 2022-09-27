using System.Collections;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class TestPoisonEffect : StatusEffect
	{
		public TestPoisonEffect(GameObject target) : base(target){}

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