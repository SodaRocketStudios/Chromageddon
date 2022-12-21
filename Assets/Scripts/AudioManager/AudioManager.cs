using UnityEngine;
using UnityEngine.Audio;

namespace SRS
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager Instance;

		[SerializeField] private AudioMixer mixer;

		private AudioSource MusicSource;
		private AudioSource EffectSource;

		private void Awake()
		{
			Instance = this;

			MusicSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Music")[0];
			EffectSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Effects")[0];
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

		public void SetMasterVolume(float level)
		{
			level = LinearToDecibel(level);
			mixer.SetFloat("VolumeMaster", level);
		}

		public void SetMusicVolume(float level)
		{
			level = LinearToDecibel(level);
			mixer.SetFloat("VolumeMusic", level);
		}

		public void SeteffectsVolume(float level)
		{
			level = LinearToDecibel(level);
			mixer.SetFloat("VolumeEffects", level);
		}

		private float LinearToDecibel(float value)
		{
			if(value <= 0)
			{
				return -80;
			}

			return 20*Mathf.Log10(value);
		}
	}
}