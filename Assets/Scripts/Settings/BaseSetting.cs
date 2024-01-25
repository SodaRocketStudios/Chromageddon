using System;
using UnityEngine;

namespace SRS.Settings
{
	[Serializable]
	public abstract class BaseSetting
	{
		[SerializeField] protected string name;
		public string Name
		{
			get => name;
		}

		public void Save()
		{
			OnSave();
			Apply();
		}

		public void Load()
		{
			Debug.Log($"Load {name}");
			OnLoad();
			Apply();
		}

		public void Reset()
		{
			PlayerPrefs.DeleteKey(name);
			Load();
		}


		protected abstract void OnSave();

		protected abstract void OnLoad();

		protected abstract void Apply();
	}
}