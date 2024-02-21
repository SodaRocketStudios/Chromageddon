using UnityEngine;

namespace SRS.Settings
{
    public class FloatSettingWrapper : SettingWrapper
    {
		[SerializeField] private FloatSetting setting;

        public override void Load()
        {
            setting.Load();
        }

        public override void Save()
        {
            setting.Save();
        }

		public void Change(float value)
		{
			setting.Value = value;
		}
    }
}