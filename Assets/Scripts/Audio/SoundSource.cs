using UnityEngine;
using SRS.Utils.ObjectPooling;
using System.Collections;
using System;

namespace SRS.Audio
{
	public class SoundSource : PooledObject
	{
		public static Action<Sound> OnComplete;

		private AudioSource source;

		private Sound sound;

		private void Awake()
		{
			source = GetComponent<AudioSource>();
		}

		public void Play(Sound sound)
		{
			this.sound = sound;

			if(sound == null || sound.Clip == null)
			{
				OnComplete?.Invoke(sound);
				ReturnToPool();
				return;
			}

			source.clip = sound.Clip;
			source.outputAudioMixerGroup = sound.MixerGroup;
			source.Play();

			StartCoroutine(ReturnWhenComplete());
		}

		private IEnumerator ReturnWhenComplete()
		{
			yield return new WaitForSecondsRealtime(source.clip.length);

			OnComplete?.Invoke(sound);

			ReturnToPool();
		}
	}
}