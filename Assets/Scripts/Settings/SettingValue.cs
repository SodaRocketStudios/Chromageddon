using UnityEngine;

namespace SRS.Settings
{
	public class SettingValue<T>
	{
		private T value;
		public T Value
		{
			get => value;
			set
			{
				if(!value.Equals(LastValue))
				{
					IsDirty = true;
				}
				this.value = value;
			}
		}

		[SerializeField] private T defaultValue;
		public T DefaultValue
		{
			get => defaultValue;
			set => defaultValue = value;
		}

		public bool IsDirty{get; set;}

		public T LastValue{get; set;}
	}
}