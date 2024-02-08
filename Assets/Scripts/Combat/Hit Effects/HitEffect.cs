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

		public void Trigger(GameObject target)
		{
			foreach(Effect effect in effects)
			{
				effect.Apply(target);
			}
			
			ParticleSystem system = particleManager?.PlayParticles(target.transform.position, Quaternion.identity, particleColor);
			if(system != null)
			{
				system.GetComponent<TargetFollower>().Target = target.transform;
				target.GetComponent<HitHandler>().Health.OnDeath += system.GetComponent<PooledObject>().ReturnToPool;
			}
		}

		public float GetProcChance(StatContainer stats)
		{
			return stats[procStat].Value;
		}
	}
}