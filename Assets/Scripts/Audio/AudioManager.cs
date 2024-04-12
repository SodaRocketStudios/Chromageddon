using UnityEngine;
using SRS.Utils.ObjectPooling;
using System.Collections.Generic;

namespace SRS.Audio
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager Instance;

		[SerializeField, Min(1)] private int soundCap;

		[SerializeField] private ObjectPool pool;

		private Dictionary<string, int> soundCount = new();

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(this);
			}

			SoundSource.OnComplete += OnSoundEnd;
		}

		public void Play(Sound sound)
		{
			if(sound == null)
			{
				return;
			}
			
			if(soundCount.ContainsKey(sound.name) == false)
			{
				soundCount[sound.name] = 0;
			}

			if(soundCount[sound.name] < sound.SoundCap)
			{
				SoundSource source = pool.Get().GetComponent<SoundSource>();
				soundCount[sound.name]++;
				source.Play(sound);
			}
		}

		private void OnSoundEnd(Sound sound)
		{
			soundCount[sound.name]--;
		}
	}
}