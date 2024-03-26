using SRS.Utils.ObjectPooling;
using UnityEngine;

namespace SRS.Audio
{
	public class SoundSource : PooledObject
	{
		private AudioSource source;

		public void Play(Sound sound)
		{
			if(sound == null)
			{
				return;
			}
			
			source = GetComponent<AudioSource>();
			source.clip = sound.Clip;
			source.outputAudioMixerGroup = sound.MixerGroup;
			source.Play();

			Monitor();
		}

		private async void Monitor()
		{
			if(source == null)
			{
				ReturnToPool();
				return;
			}

			while(source.isPlaying)
			{
				await Awaitable.EndOfFrameAsync();
			}

			ReturnToPool();

			return;
		}
	}
}