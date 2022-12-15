using UnityEngine;

namespace SRS.GameManager
{
	public class GameTimer : MonoBehaviour
	{
		public static GameTimer Instance;

		public float Time{get; private set;}
		private TimerState state;


		private void Awake()
		{
			if(GameTimer.Instance == null)
			{
				Instance = this;
			}
			else if(GameTimer.Instance != this)
			{
				Destroy(gameObject);
			}

			state = TimerState.Running;
		}

		public void StartTimer()
		{
			state = TimerState.Running;
		}

		public void PauseTimer()
		{
			state = TimerState.Paused;
		}

		public void StopTimer()
		{
			state = TimerState.Stopped;
		}
		
		private void Update()
		{
			switch(state)
			{
				case TimerState.Running:
                    Time += UnityEngine.Time.deltaTime;
					break;
				case TimerState.Paused:
					break;
				case TimerState.Stopped:
					Time = 0;
					break;
				default:
					break;
			}
		}

		private enum TimerState
		{
			Running,
			Paused,
			Stopped
		}
	}
}