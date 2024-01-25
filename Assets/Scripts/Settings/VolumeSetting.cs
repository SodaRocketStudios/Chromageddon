using SRS.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace SRS.Settings
{
	public class VolumeSetting: SettingWrapper
	{
		[SerializeField] private AudioMixer mixer;

		[SerializeField] private string parameter;

		private void Awake()
		{
			setting = new FloatSetting();
			(setting as FloatSetting).OnApply += Set;
			Load();
		}

		protected void Set(FloatRange value)
		{
			mixer.SetFloat(parameter, 20*Mathf.Log10(value.Current));
		}
    }
}