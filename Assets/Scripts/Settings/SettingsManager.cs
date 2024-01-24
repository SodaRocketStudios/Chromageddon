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
			GameObject[] gameObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
			settings = gameObjects.OfType<ISetting>() as List<ISetting>;

			Load();
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