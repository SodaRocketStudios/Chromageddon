using System;
using UnityEngine;
using UnityEngine.Events;
using SRS.Utils;

namespace SRS.Settings
{
    [Serializable]
    public class IntSetting : Setting
    {
        public Action<int> OnApply;
		public UnityEvent<int> OnApplyEvent;

		[SerializeField] private IntRange value = new();
		public int Value
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

		[SerializeField] private int defaultValue;
		public int DefaultValue
		{
			get => defaultValue;
			set => defaultValue = value;
		}

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