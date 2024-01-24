using UnityEngine;

namespace SRS.Settings
{
	public abstract class Setting<T> : MonoBehaviour
	{
		protected new string name;

		private T value;
		public T Value
		{
			get => value;
			set
			{
				if(!value.Equals(lastValue))
				{
					isDirty = true;
				}
				this.value = value;
			}
		}

		protected bool isDirty;

		protected T defaultValue;

		private T lastValue;

		public void Save()
		{
			OnSave();
			lastValue = value;
		}

		public void Load()
		{
			OnLoad();
			lastValue = value;
		}

		public abstract void OnSave();

		public abstract void OnLoad();
	}
}