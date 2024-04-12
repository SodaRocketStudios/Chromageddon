using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;
using SRS.Utils.VFX;
using SRS.Utils;
using SRS.Utils.ObjectPooling;

namespace SRS.Combat.HitEffects
{

	[CreateAssetMenu(fileName = "New Hit Effect", menuName = "Combat/Hit Effects/Hit Effect")]
	public class HitEffect : ScriptableObject
	{
		[SerializeField] private new string name;

		[SerializeField] private string description;

		[SerializeField] private string procStat;

		[SerializeField] private List<Effect> effects = new();

		[SerializeField] private ParticleManager particleManager;

		[SerializeField] private Color particleColor;

		public void Trigger(GameObject source, GameObject target)
		{
			ParticleSystem system = particleManager?.PlayParticles(target.transform.position, Quaternion.identity, particleColor);
			if(system != null)
			{
				TargetFollower follower = system.GetComponent<TargetFollower>();
				if(follower != null)
				{
					follower.Target = target.transform;
				}

				HitHandler hitHandler = target.GetComponent<HitHandler>();
				hitHandler.Health.OnDeath += system.GetComponent<PooledObject>().ReturnToPool;
			}

			foreach(Effect effect in effects)
			{
				effect.Apply(source, target);
			}
		}

		public float GetProcChance(StatContainer stats)
		{
			return stats[procStat].Value;
		}
	}
}