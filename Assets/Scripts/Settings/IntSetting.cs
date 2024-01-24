using UnityEngine;

namespace SRS.Settings
{
    public class IntSetting : Setting<int>
    {
        public override void OnSave()
        {
            PlayerPrefs.SetInt(name, Value);
        }

        public override void OnLoad()
        {
            Value = PlayerPrefs.GetInt(name, defaultValue);
        }
    }
}