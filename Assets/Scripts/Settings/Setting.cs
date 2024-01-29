using System;
using UnityEngine;

namespace SRS.Settings
{
	[Serializable]
	public abstract class Setting
	{
		[SerializeField] protected string name;
		public string Name
		{
			get => name;
			set => name = value;
		}

		public void Save()
		{
			OnSave();
			Apply();
		}

		public void Load()
		{
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