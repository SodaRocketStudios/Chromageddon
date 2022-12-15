using UnityEngine;

namespace SRS.Particles
{
	public class Particle : MonoBehaviour
	{
		private void OnParticleSystemStopped()
		{
			Debug.Log("Stopped");
		}
	}
}