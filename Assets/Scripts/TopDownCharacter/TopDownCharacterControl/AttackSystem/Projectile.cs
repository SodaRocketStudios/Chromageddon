using UnityEngine;
using System;
using System.Collections.Generic;
using SRS.Stats;
using SRS.StatusEffects;
using SRS.Extensions;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class Projectile : MonoBehaviour
	{
		private Dictionary<string, Stat> attackStats;
		private LayerMask mask;

		private static List<Type> effects = new List<Type>(){typeof(TestPoisonEffect)};

		private float speed;
		private float lifetime;
		private float despawnTime;

		private static System.Random randomGenerator = new System.Random(System.DateTime.Now.Millisecond);

		public void Initialize(Dictionary<string, Stat> stats, LayerMask collisionMask)
		{
			attackStats = new Dictionary<string, Stat>(stats);
			mask = collisionMask;

			speed = attackStats["Speed"].Value;
			lifetime = attackStats["Lifetime"].Value;

			despawnTime = Time.time + lifetime;
		}

		void Update()
		{
			if(Time.time > despawnTime)
			{
				Despawn();
			}

			transform.Translate(transform.right*Time.deltaTime*speed, Space.World);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if((mask.value & (1 << other.gameObject.layer)) > 0)
			{
				// TO DO -- Perform on hit logic. This is where an IDamageable interface could be useful.
				StatusEffectTracker targetEffectTracker;
				if(other.gameObject.TryGetComponent<StatusEffectTracker>(out targetEffectTracker))
				{
					foreach(Type effectType in effects)
					{
						StatusEffect effect = Activator.CreateInstance(effectType) as StatusEffect;

						float procChance = attackStats[effect.procStat].Value;

						int randomRange = DetermineRandomRange(procChance);
						float randomNumber = 1.0f*randomGenerator.Next(randomRange)/randomRange;

						if(randomNumber < procChance)
						{
							targetEffectTracker.ApplyEffect(effect);
						}
					}
				}
				Despawn();
			}
		}

		private void Despawn()
		{
			// TO DO -- Switch to an object pooling solution for projectiles.
			Destroy(gameObject);
		}

		private static int DetermineRandomRange(float probability)
		{
			return 100 * (int)Mathf.Pow(10, probability.DecimalPlaces());
		}
	}
}