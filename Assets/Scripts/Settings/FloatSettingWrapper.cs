using UnityEngine;

namespace SRS.Settings
{
    public class FloatSettingWrapper : SettingWrapper
    {
		[SerializeField] private FloatSetting setting;

        public override void Load()
        {
            setting.Save();
        }

        public override void Save()
        {
            setting.Load();
        }
    }
}