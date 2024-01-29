using System;
using SRS.Utils;
using UnityEngine;

namespace SRS.Settings
{
    [Serializable]
    public class IntSetting : Setting
    {
        public Action<IntRange> OnApply;

		[SerializeField] private IntRange value = new();
		public IntRange Value
		{
			get => value;
			set
			{
				this.value = value;
				Apply();
			}
		}

		protected override void Apply()
		{
			OnApply?.Invoke(Value);
		}

		[SerializeField] private IntRange defaultValue;
		public IntRange DefaultValue
		{
			get => defaultValue;
			set => defaultValue = value;
		}

        protected override void OnSave()
        {
            PlayerPrefs.SetInt(name, Value.Current);
        }

        protected override void OnLoad()
        {
            Value.Current = PlayerPrefs.GetInt(name, DefaultValue.Current);
        }
    }
}