using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SRS.Settings
{
	public class SettingsManager : MonoBehaviour
	{
		private List<SettingWrapper> settings;

		private void Start()
		{
			settings = GetComponentsInChildren<SettingWrapper>().ToList();
			
			Load();
		}

		public void Save()
		{
			foreach(SettingWrapper setting in settings)
			{
				setting.Save();
			}
		}

		public void Load()
		{
			foreach(SettingWrapper setting in settings)
			{
				setting.Load();
			}
		}
	}
}