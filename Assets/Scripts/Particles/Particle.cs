using UnityEngine;
using UnityEngine.Events;

namespace SRS.Particles
{
    public class Particle : MonoBehaviour
    {
        public UnityEvent<ParticleSystem> OnParticleSystemEnd;

        private void OnParticleSystemStopped()
        {
            OnParticleSystemEnd.Invoke(gameObject.GetComponent<ParticleSystem>());
        }
    }
}
