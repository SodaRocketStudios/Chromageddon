using System;
using UnityEngine;

namespace SRS.Settings
{
	[Serializable]
	public abstract class Setting<T> : BaseSetting
	{
		public Action<T> OnApply;

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

		protected override void Apply()
		{
			OnApply?.Invoke(Value);
		}

		[SerializeField] private T defaultValue;
		public T DefaultValue
		{
			get => defaultValue;
			set => defaultValue = value;
		}
	}
}