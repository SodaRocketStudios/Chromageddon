using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SRS.GameManagement
{
	public class Game : MonoBehaviour
	{
		public static Game Instance;

		public bool Running{get; private set;} = false;

		public Action<bool> OnPlayPause;

		public Action OnGameOver;

		private bool ignorePauseInput = true;
		public bool IgnorePauseInput
		{
			get => ignorePauseInput;
			set => ignorePauseInput = value;
		}

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
			ignorePauseInput = false;
			OnPlayPause?.Invoke(Running);
		}

		public void TogglePause()
		{
			if(ignorePauseInput)
			{
				return;
			}

			if(Running == false)
			{
				Play();
				return;
			}

			Pause();
		}

		public void GameOver()
		{
			OnGameOver?.Invoke();
			Pause();
			ignorePauseInput = true;
		}

		public void Restart()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			ignorePauseInput = true;
		}

		public void Quit()
		{
			Application.Quit();
		}
	}
}