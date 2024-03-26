using UnityEngine;
using SRS.Utils.ObjectPooling;
using System.Collections;
using System;

namespace SRS.Audio
{
	public class SoundSource : PooledObject
	{
		public static Action<SoundSource> OnComplete;

		private AudioSource source;

		private void Awake()
		{
			source = GetComponent<AudioSource>();
		}

		public void Play(Sound sound)
		{
			if(sound == null || sound.Clip == null)
			{
				OnComplete?.Invoke(this);
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

			OnComplete?.Invoke(this);

			ReturnToPool();
		}
	}
}