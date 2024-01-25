using UnityEngine;

namespace SRS.Settings
{
    public class StringSetting : Setting<string>
    {
        protected override void OnSave()
        {
            PlayerPrefs.SetString(name, value.Value);
        }

        protected override void OnLoad()
        {
            value.Value = PlayerPrefs.GetString(name, value.DefaultValue);
        }
    }
}