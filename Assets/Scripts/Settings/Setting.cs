using UnityEngine;
using UnityEngine.Events;

namespace SRS.Settings
{
	public abstract class Setting<T> : MonoBehaviour, ISetting
	{
		public UnityEvent<T> OnApply;

		[SerializeField] protected new string name;

		[SerializeField] protected T defaultValue;

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

		private bool isDirty = true;

		private T lastValue;

		public void Save()
		{
			if(isDirty)
			{
				OnSave();
				Apply();
			}
		}

		public void Load()
		{
			if(isDirty)
			{
				OnLoad();
				Apply();
			}
		}

		private void Apply()
		{
			if(isDirty)
			{
				OnApply?.Invoke(Value);
				isDirty = false;
				lastValue = value;
			}
		}

		public abstract void OnSave();

		public abstract void OnLoad();
	}
}