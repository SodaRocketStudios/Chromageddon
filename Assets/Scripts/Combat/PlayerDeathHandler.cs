using UnityEngine;
using UnityEngine.Events;

namespace SRS.Combat
{
	public class PlayerDeathHandler : MonoBehaviour
	{
		public UnityEvent OnDeath;

		private void Start()
		{
			GetComponent<HitHandler>().Health.OnDeath += KillPlayer;
		}

		public void KillPlayer()
		{
			OnDeath?.Invoke();
		}
	}
}