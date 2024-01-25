using UnityEngine;

namespace SRS.Settings
{
	public abstract class SettingHandler<T> : ScriptableObject
	{
		public abstract void Save(string name, T value);

		public abstract T Load(string name);
	}
}