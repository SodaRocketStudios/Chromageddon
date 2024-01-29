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

		[ContextMenu("Save")]
		public void Save()
		{
			foreach(SettingWrapper setting in settings)
			{
				setting.Save();
			}
		}

		[ContextMenu("Load")]
		public void Load()
		{
			foreach(SettingWrapper setting in settings)
			{
				setting.Load();
			}
		}

		[ContextMenu("Reset")]
		public void Reset()
		{
			PlayerPrefs.DeleteAll();
		}
	}
}