using UnityEngine;
using SRS.Utils;
using System;

namespace SRS.Settings
{
    [Serializable]
    public class FloatSetting : Setting
    {
        public Action<FloatRange> OnApply;

		private FloatRange value;
		public FloatRange Value
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

		[SerializeField] private float defaultValue;
		public float DefaultValue
		{
			get => defaultValue;
			set => defaultValue = value;
		}

        protected override void OnSave()
        {
            PlayerPrefs.SetFloat(name, Value.Current);
        }

        protected override void OnLoad()
        {
            Value.Current = PlayerPrefs.GetFloat(name, defaultValue);
        }
    }
}