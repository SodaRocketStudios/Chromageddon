using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.Audio
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager Instance;

		[SerializeField, Min(1)] private int soundCap;

		[SerializeField] private ObjectPool pool;

		private int activeSounds;

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(this);
			}
		}

		public void Play(Sound sound)
		{
			if(activeSounds >= soundCap)
			{
				return;
			}

			pool.Get().GetComponent<SoundSource>().Play(sound);
		}
	}
}