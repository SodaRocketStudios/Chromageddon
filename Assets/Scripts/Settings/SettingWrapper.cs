using UnityEngine;

namespace SRS.Settings
{
	public abstract class SettingWrapper : MonoBehaviour
	{
		public abstract void Save();

		public abstract void Load();
	}
}