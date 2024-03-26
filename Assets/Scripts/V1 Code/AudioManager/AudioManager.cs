using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SRS.AudioV1
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

			foreach(Sound sound in effects)
			{
				sound.Source = gameObject.AddComponent<AudioSource>();
				sound.Source.clip = sound.Clip;
				sound.Source.volume = sound.Volume;
			}

			foreach(Sound sound in music)
			{
				sound.Source = gameObject.AddComponent<AudioSource>();
				sound.Source.clip = sound.Clip;
				sound.Source.volume = sound.Volume;
			}
		}

		public void PlayMusic(string soundName)
		{
			music.Find(e => e.Name == soundName).Source.Play();
		}

		public void PlayEffect(string soundName)
		{
			effects.Find(e => e.Name == soundName).Source.Play();
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