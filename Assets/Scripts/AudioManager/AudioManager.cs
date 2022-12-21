using UnityEngine;
using UnityEngine.Audio;

namespace SRS
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager Instance;
		[SerializeField] private AudioMixerGroup masterGroup;
		[SerializeField] private AudioMixerGroup musicGroup;
		[SerializeField] private AudioMixerGroup effectsGroup;

		private AudioSource MusicSource;
		private AudioSource EffectSource;

		private void Awake()
		{
			Instance = this;

			MusicSource = gameObject.AddComponent<AudioSource>();
			EffectSource = gameObject.AddComponent<AudioSource>();

			MusicSource.outputAudioMixerGroup = musicGroup;
			EffectSource.outputAudioMixerGroup = effectsGroup;
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
			masterGroup.audioMixer.SetFloat("VolumeMaster", level);
		}

		public void SetMusicVolume(float level)
		{
			level = LinearToDecibel(level);
			masterGroup.audioMixer.SetFloat("VolumeMusic", level);
		}

		public void SetEffectsVolume(float level)
		{
			level = LinearToDecibel(level);
			masterGroup.audioMixer.SetFloat("VolumeEffects", level);
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