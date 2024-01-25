using UnityEngine;

namespace SRS.Settings
{
	public abstract class SettingWrapper : MonoBehaviour
	{
		[SerializeField] protected Setting setting;

		public void Save()
		{
			setting.Save();
		}

		public void Load()
		{
			setting.Load();
		}
	}
}