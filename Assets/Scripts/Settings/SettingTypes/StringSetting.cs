using System;
using UnityEngine;
using UnityEngine.Events;

namespace SRS.Settings
{
    [Serializable]
    public class StringSetting : Setting
    {
        public Action<string> OnApply;
		public UnityEvent<string> OnApplyEvent;

		private string value;
		public string Value
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
			OnApplyEvent?.Invoke(Value);
		}

		[SerializeField] private string defaultValue;
		public string DefaultValue
		{
			get => defaultValue;
			set => defaultValue = value;
		}

        protected override void OnSave()
        {
            PlayerPrefs.SetString(name, Value);
        }

        protected override void OnLoad()
        {
            Value = PlayerPrefs.GetString(name, DefaultValue);
        }
    }
}