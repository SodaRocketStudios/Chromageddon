using UnityEngine;
using UnityEngine.Pool;

namespace SRS.Particles
{
	public class DeathParticles : MonoBehaviour
	{	
		private ObjectPool<ParticleSystem> pool;

		[SerializeField] private ParticleSystem particlePrefab;

		private void Awake()
		{
			pool = new ObjectPool<ParticleSystem>(Create, OnGet, OnRelease);
		}

		public void Play(GameObject target)
		{
			ParticleSystem particles = pool.Get();
			particles.transform.position = target.transform.position;
			particles.startColor = target.GetComponent<SpriteRenderer>().color;
			particles.Play();
		}

		
		private ParticleSystem Create()
		{
			ParticleSystem newParticle = Instantiate(particlePrefab);
			newParticle.gameObject.SetActive(false);

			return newParticle;
		}

		private void OnGet(ParticleSystem particleSystem)
		{
			particleSystem.gameObject.SetActive(true);
		}

		private void OnRelease(ParticleSystem particleSystem)
		{
			particleSystem.gameObject.SetActive(false);
		}
	}
}