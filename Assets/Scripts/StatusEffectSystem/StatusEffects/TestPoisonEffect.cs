using System.Collections;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class TestPoisonEffect : StatusEffect
	{
        protected override float duration {get; set;} = 2;

		public override string procStat {get; protected set;} = "PoisonChance";

		private float slowAmount = .75f;

		private float tickDelay = 0.5f;
		private int tickDamage;

		private float nextTickTime = 0;

		private int maxTicks = 0;

		public TestPoisonEffect() : base(){}

        protected override IEnumerator EffectCoroutine()
		{
			// Apply slow
			targetData.CharacterStats["MoveSpeed"].MultiplicativeModifier *= slowAmount;

			Debug.Log("Apply Poison");

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
						Debug.Log("Posion");
					}

					nextTickTime = Time.time + tickDelay;
				}

				yield return new WaitForEndOfFrame();
			}

			// Remove slow
			targetData.CharacterStats["MoveSpeed"].MultiplicativeModifier /= slowAmount;
		}
	}
}