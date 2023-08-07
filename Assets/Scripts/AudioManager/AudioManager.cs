using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SRS.Audio
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager Instance;

		[SerializeField] private List<Sound> music = new();
		[SerializeField] private List<Sound> effects = new();

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

		public void PlayMusic(string sound)
		{
			AudioClip clip = music.Find(e => e.Name == sound).audioClip;
			if(clip != null)
			{
				MusicSource.clip = clip;
				MusicSource.Play();
			}
			else
			{
				Debug.LogWarning("Audio Clip Not Found", gameObject);
			}
		}

		public void PlayEffect(string sound)
		{
			AudioClip clip = effects.Find(e => e.Name == sound).audioClip;
			if(clip != null)
			{
				EffectSource.clip = clip;
				EffectSource.Play();
			}
			else
			{
				Debug.LogWarning("Audio Clip Not Found", gameObject);
			}
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