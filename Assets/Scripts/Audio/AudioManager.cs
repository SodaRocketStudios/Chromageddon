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

		private List<SoundSource> activeSounds = new();

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
			if(activeSounds.Count >= soundCap)
			{
				return;
			}

			SoundSource source = pool.Get().GetComponent<SoundSource>();
			activeSounds.Add(source);
			source.Play(sound);
		}

		private void OnSoundEnd(SoundSource source)
		{
			activeSounds.Remove(source);
		}
	}
}