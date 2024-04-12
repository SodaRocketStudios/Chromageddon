using UnityEngine;
using UnityEngine.Audio;

namespace SRS.Audio
{
	[CreateAssetMenu(fileName = " New Sound", menuName = "Audio/Sound")]
	public class Sound : ScriptableObject
	{
		[SerializeField] private AudioClip clip;
		public AudioClip Clip
		{
			get => clip;
		}

		[SerializeField] private AudioMixerGroup mixerGroup;
		public AudioMixerGroup MixerGroup
		{
			get => mixerGroup;
		}

		[SerializeField, Min(0)] private int soundCap;
		public int SoundCap
		{
			get => soundCap;
		}
	}
}