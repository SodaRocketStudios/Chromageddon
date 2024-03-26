using UnityEngine;
using SRS.Utils.ObjectPooling;
using System.Collections;

namespace SRS.Audio
{
	public class SoundSource : PooledObject
	{
		private AudioSource source;

		private void Awake()
		{
			source = GetComponent<AudioSource>();
		}

		public void Play(Sound sound)
		{
			if(sound == null || sound.Clip == null)
			{
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

			ReturnToPool();
		}
	}
}