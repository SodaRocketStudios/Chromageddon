using UnityEngine;

namespace SRS
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager Instance;

		private AudioSource MusicSource;
		private AudioSource EffectSource;

		private void Awake()
		{
			Instance = this;
		}

		public void PlayMusic(AudioClip clip)
		{
			MusicSource.clip = clip;
			MusicSource.Play();
		}

		public void PlayEffect(AudioClip clip)
		{
			EffectSource.PlayOneShot(clip);
		}
	}
}