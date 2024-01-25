using UnityEngine;
using SRS.Utils;

namespace SRS.Settings
{
    public class FloatSetting : Setting<FloatRange>
    {
        protected override void OnSave()
        {
            PlayerPrefs.SetFloat(name, value.Value.Current);
        }

        protected override void OnLoad()
        {
            value.Value.Current = PlayerPrefs.GetFloat(name, value.DefaultValue.Current);
        }
    }
}