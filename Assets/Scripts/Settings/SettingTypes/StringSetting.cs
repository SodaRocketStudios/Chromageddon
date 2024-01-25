using UnityEngine;

namespace SRS.Settings
{
    public class StringSetting : Setting<string>
    {
        protected override void OnSave()
        {
            PlayerPrefs.SetString(name, Value);
        }

        protected override void OnLoad()
        {
            Value = PlayerPrefs.GetString(name, DefaultValue);
        }
    }
}