using UnityEngine;

namespace SRS.Particles
{
	public class DeathParticles : MonoBehaviour
	{
		private ParticlePool pool;

		private void Start()
		{
			pool = GetComponent<ParticlePool>();	
		}

		public void Play(GameObject target)
		{
			ParticleSystem particles = pool.Pool.Get();
			particles.transform.position = target.transform.position;
		}
	}
}