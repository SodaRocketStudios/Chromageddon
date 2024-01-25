using UnityEngine;

namespace SRS.Settings
{
    public class IntSetting : Setting<int>
    {
        protected override void OnSave()
        {
            PlayerPrefs.SetInt(name, value.Value);
        }

        protected override void OnLoad()
        {
            value.Value = PlayerPrefs.GetInt(name, value.DefaultValue);
        }
    }
}