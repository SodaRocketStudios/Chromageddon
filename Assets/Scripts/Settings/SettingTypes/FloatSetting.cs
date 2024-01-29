using System;
using UnityEngine;
using UnityEngine.Events;
using SRS.Utils;

namespace SRS.Settings
{
    [Serializable]
    public class FloatSetting : Setting
    {
        public Action<float> OnApply;
		public UnityEvent<float> OnApplyEvent;

		[SerializeField] private FloatRange value = new();
		public float Value
		{
			get => value.Current;
			set
			{
				this.value.Current = value;
				Apply();
			}
		}

		protected override void Apply()
		{
			OnApply?.Invoke(Value);
			OnApplyEvent?.Invoke(Value);
		}

		[SerializeField] private float defaultValue;
		public float DefaultValue
		{
			get => defaultValue;
			set => defaultValue = value;
		}

        protected override void OnSave()
        {
            PlayerPrefs.SetFloat(name, Value);
        }

        protected override void OnLoad()
        {
            Value = PlayerPrefs.GetFloat(name, defaultValue);
        }
    }
}