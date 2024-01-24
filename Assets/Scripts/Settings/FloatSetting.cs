using UnityEngine;

namespace SRS.Settings
{
    public class FloatSetting : Setting<float>
    {
        public override void OnSave()
        {
            PlayerPrefs.SetFloat(name, Value);
        }

        public override void OnLoad()
        {
            Value = PlayerPrefs.GetFloat(name, defaultValue);
        }
    }
}