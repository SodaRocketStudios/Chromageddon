using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.Utils.VFX
{
	[CreateAssetMenu(fileName = "New Particle Manager", menuName = "VFX/Particle Manager")]
	public class ParticleManager : ScriptableObject
	{
		[SerializeField] private ObjectPool pool;

		public ParticleSystem PlayParticles(Vector3 position, Quaternion rotation)
		{
			ParticleSystem system = GetSystem(position, rotation);
			StartParticles(system);
			return system;
		}

		public ParticleSystem PlayParticles(Vector3 position, Quaternion rotation, Color color)
		{
			ParticleSystem system = GetSystem(position, rotation);
			ParticleSystem.MainModule mainModule = system.main;
			mainModule.startColor = color;
			StartParticles(system);
			return system;
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