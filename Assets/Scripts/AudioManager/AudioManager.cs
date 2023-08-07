using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SRS.Audio
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager Instance;
		[SerializeField] private AudioMixerGroup masterGroup;
		[SerializeField] private AudioMixerGroup musicGroup;
		[SerializeField] private AudioMixerGroup effectsGroup;

		[SerializeField] private List<Sound> music = new();
		[SerializeField] private List<Sound> effects = new();

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

		public void PlayMusic(string sound)
		{
			AudioClip clip = music.Find(e => e.Name == sound).Clip;
			MusicSource.clip = clip;
			MusicSource.Play();
		}

		public void PlayEffect(string sound)
		{
			AudioClip clip = effects.Find(e => e.Name == sound).Clip;
			EffectSource.clip = clip;
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