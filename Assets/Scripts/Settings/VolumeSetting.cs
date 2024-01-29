using UnityEngine;
using UnityEngine.Audio;

namespace SRS.Settings
{
	public class VolumeSetting: SettingWrapper
	{
		[SerializeField] private AudioMixer mixer;

		[SerializeField] private string parameter;

		[SerializeField] private FloatSetting setting;

		private void Awake()
		{
			setting.OnApply += Set;
			Load();
		}

		public void Change(float value)
		{
			setting.Value = value;
		}

        public override void Save()
        {
            setting.Save();
        }

        public override void Load()
        {
            setting.Load();
        }

		protected void Set(float value)
		{
			mixer.SetFloat(parameter, 20*Mathf.Log10(value));
		}
    }
}