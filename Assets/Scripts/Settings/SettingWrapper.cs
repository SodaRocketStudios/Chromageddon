using UnityEngine;

namespace SRS.Settings
{
	public class SettingWrapper : MonoBehaviour
	{
		[SerializeField] private ISetting setting;

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