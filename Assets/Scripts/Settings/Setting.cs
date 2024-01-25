using System;
using UnityEngine;

namespace SRS.Settings
{
	[Serializable]
	public abstract class Setting<T> : ISetting
	{
		public Action<T> OnApply;

		[SerializeField] protected string name;
		public string Name
		{
			get => name;
		}

		private T value;
		public T Value
		{
			get => value;
			set
			{
				this.value = value;
				Apply();
			}
		}

		[SerializeField] private T defaultValue;
		public T DefaultValue
		{
			get => defaultValue;
			set => defaultValue = value;
		}

		public void Save()
		{
			OnSave();
			Apply();
		}

		public void Load()
		{
			Debug.Log($"Load {name}");
			OnLoad();
			Apply();
		}

		public void Reset()
		{
			PlayerPrefs.DeleteKey(name);
			Load();
		}

		private void Apply()
		{
			OnApply?.Invoke(Value);
		}

		protected abstract void OnSave();

		protected abstract void OnLoad();
	}
}