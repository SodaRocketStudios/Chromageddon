using UnityEngine;

namespace SRS.Settings
{
    public class StringSetting : Setting<string>
    {
        public override void OnSave()
        {
            PlayerPrefs.SetString(name, Value);
        }

        public override void OnLoad()
        {
            Value = PlayerPrefs.GetString(name, defaultValue);
        }
    }
}