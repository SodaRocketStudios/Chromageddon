using System.Collections;
using UnityEngine;

namespace SRS.StatusEffects
{
	[CreateAssetMenu(fileName = "Test Poison", menuName = "Status Effects/Test Poison")]
	public class TestPoisonEffect : StatusEffect
	{
		private float slowAmount = .75f;

		private float tickDelay = 0.5f;
		private int tickDamage;

		private float nextTickTime = 0;

		private int maxTicks = 0;

        protected override IEnumerator EffectCoroutine()
		{
			// Apply slow
			targetStats.Character["MoveSpeed"].MultiplicativeModifier *= slowAmount;

			nextTickTime = Time.time;

			while(Time.time < endTime)
			{
				// Ticking damage
				if(Time.time > nextTickTime)
				{
					maxTicks = (int)((endTime - Time.time)/tickDelay);

					int damageTicks = (int)((Time.time - nextTickTime)/tickDelay) + 1;
					damageTicks = (int)Mathf.Clamp(damageTicks, 0, maxTicks);

					for(int i = 0 ; i < damageTicks; i++)
					{
						targetHealth.Damage(tickDamage);
					}

					nextTickTime = Time.time + tickDelay;
				}

				yield return new WaitForEndOfFrame();
			}

			// Remove slow
			targetStats.Character["MoveSpeed"].MultiplicativeModifier /= slowAmount;
		}
	}
}