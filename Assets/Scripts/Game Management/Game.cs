using System;
using UnityEngine;

namespace SRS.GameManagement
{
	public class Game : MonoBehaviour
	{
		public static Game Instance;

		public bool Running{get; private set;} = false;

		public Action<bool> OnPlayPause;

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(this);
			}

			Pause();
		}

		public void Pause()
		{
			Time.timeScale = 0;
			Running = false;
			OnPlayPause?.Invoke(Running);
		}

		public void Play()
		{
			Time.timeScale = 1;
			Running = true;
			OnPlayPause?.Invoke(Running);
		}

		public void Quit()
		{
			Application.Quit();
		}
	}
}