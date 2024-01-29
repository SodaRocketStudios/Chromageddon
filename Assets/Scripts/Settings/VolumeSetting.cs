using SRS.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace SRS.Settings
{
	public class VolumeSetting: SettingWrapper
	{
		[SerializeField] private AudioMixer mixer;

		[SerializeField] private string parameter;

		[SerializeField] private FloatSetting setting = new();

		private void Awake()
		{
			setting = new FloatSetting();
			setting.OnApply += Set;
			setting.Name = name;
			Load();
		}

		protected void Set(FloatRange value)
		{
			mixer.SetFloat(parameter, 20*Mathf.Log10(value.Current));
		}

        public override void Save()
        {
            setting.Save();
        }

        public override void Load()
        {
            setting.Load();
        }
    }
}