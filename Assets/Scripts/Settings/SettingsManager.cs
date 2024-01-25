using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SRS.Settings
{
	public class SettingsManager : MonoBehaviour
	{
		private List<ISetting> settings;
		private void Start()
		{
			// can't use get component for interfaces
			// TODO -- use actual class for get component.
			settings = GetComponentsInChildren<ISetting>().ToList();
			Debug.Log(settings.Count);
		}

		public void Save()
		{
			foreach(ISetting setting in settings)
			{
				setting.Save();
			}
		}

		public void Load()
		{
			foreach(ISetting setting in settings)
			{
				setting.Load();
			}
		}
	}
}