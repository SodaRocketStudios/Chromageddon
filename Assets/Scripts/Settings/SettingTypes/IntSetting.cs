using UnityEngine;

namespace SRS.Settings
{
    public class IntSetting : Setting<int>
    {
        protected override void OnSave()
        {
            PlayerPrefs.SetInt(name, Value);
        }

        protected override void OnLoad()
        {
            Value = PlayerPrefs.GetInt(name, DefaultValue);
        }
    }
}