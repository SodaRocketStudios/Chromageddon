using SRS.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace SRS.Settings
{
	public class VolumeSetting : MonoBehaviour
	{
		[SerializeField] private AudioMixer mixer;

		[SerializeField] private string parameter;

		[SerializeField] FloatSetting setting = new();

		private void OnEnable()
		{
			setting.OnApply += Set;
		}

		private void OnDisable()
		{
			setting.OnApply -= Set;
		}

		private void Set(FloatRange value)
		{
			mixer.SetFloat(parameter, 20*Mathf.Log10(value.Current));
		}
	}
}