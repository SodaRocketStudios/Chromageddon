using UnityEngine;
using SRS.Utils;

namespace SRS.Settings
{
    public class FloatSetting : Setting<FloatRange>
    {
        protected override void OnSave()
        {
            PlayerPrefs.SetFloat(name, Value.Current);
        }

        protected override void OnLoad()
        {
            Value.Current = PlayerPrefs.GetFloat(name, DefaultValue.Current);
        }
    }
}