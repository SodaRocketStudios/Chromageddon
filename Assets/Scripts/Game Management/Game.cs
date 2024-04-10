using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using SRS.DataPersistence;

namespace SRS.GameManagement
{
	public class Game : MonoBehaviour
	{
		public static Game Instance;

		public bool Running{get; private set;} = false;

		public Action<bool> OnPlayPause;
		public UnityEvent OnPlay;
		public UnityEvent OnPause;

		public Action OnGameOver;

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
		}

		private void Start()
		{
			Pause();
		}

		public void Pause()
		{
			Time.timeScale = 0;
			GameTimer.Instance.PauseTimer();
			Running = false;
			OnPlayPause?.Invoke(Running);
			OnPause.Invoke();
		}

		public void Play()
		{
			Time.timeScale = 1;
			GameTimer.Instance.StartTimer();
			Running = true;
			OnPlayPause?.Invoke(Running);
			OnPlay?.Invoke();
		}

		public void TogglePause(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				if(Running)
				{
					Pause();
					return;
				}
				
				Play();
			}
		}

		public void GameOver()
		{
			OnGameOver?.Invoke();
			GameTimer.Instance.PauseTimer();
			PersistenceSystem.Instance.Save("Save");
			Pause();
		}

		public void Restart()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void Quit()
		{
			Application.Quit();
		}
	}
}