using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.Utils.VFX
{
	public class ParticleManager : MonoBehaviour
	{
		[SerializeField] private ObjectPool pool;

		public void PlayParticles(Vector3 position, Quaternion rotation)
		{
			ParticleSystem system = GetSystem(position, rotation);
			StartParticles(system);
		}

		public void PlayParticles(Vector3 position, Quaternion rotation, Color color)
		{
			ParticleSystem system = GetSystem(position, rotation);
			ParticleSystem.MainModule mainModule = system.main;
			mainModule.startColor = color;
			StartParticles(system);
		}

		private ParticleSystem GetSystem(Vector3 position, Quaternion rotation)
		{
			return pool.Get(position, rotation).GetComponent<ParticleSystem>();
		}

		private void StartParticles(ParticleSystem system)
		{
			system.Play();
		}
	}
}