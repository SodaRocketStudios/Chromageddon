using UnityEngine;
using UnityEngine.Audio;

namespace SRS.Settings
{
	public class Volume : MonoBehaviour
	{
		[SerializeField] private AudioMixer mixer;

		[SerializeField] private string parameter;

		public void Set(float value)
		{
			mixer.SetFloat(parameter, 20*Mathf.Log10(value));
		}
	}
}