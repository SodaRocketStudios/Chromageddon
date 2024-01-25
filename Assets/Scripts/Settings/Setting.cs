using System;
using UnityEngine;

namespace SRS.Settings
{
	[Serializable]
	public abstract class Setting<T> : ISetting
	{
		[SerializeField] protected string name;
		public string Name
		{
			get => name;
		}

		[SerializeField] protected SettingValue<T> value;
		public SettingValue<T> Value
		{
			get => value;
		}

		public Action<T> OnApply;

		public void Save()
		{
			if(value.IsDirty)
			{
				OnSave();
				Apply();
			}
		}

		public void Load()
		{
			if(value.IsDirty)
			{
				Debug.Log($"Load {name}");
				OnLoad();
				Apply();
			}
		}

		private void Apply()
		{
			if(value.IsDirty)
			{
				OnApply?.Invoke(value.Value);
				value.IsDirty = false;
				value.LastValue = value.Value;
			}
		}

		protected abstract void OnSave();

		protected abstract void OnLoad();
	}
}