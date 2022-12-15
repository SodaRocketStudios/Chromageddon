using UnityEngine;
using UnityEngine.Pool;

namespace SRS.Particles
{
	public class ParticlePool : MonoBehaviour
	{
		public ObjectPool<ParticleSystem> Pool;

		[SerializeField] private ParticleSystem particlePrefab;


		private void Awake()
		{
			Pool = new ObjectPool<ParticleSystem>(Create, OnGet, OnRelease);
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