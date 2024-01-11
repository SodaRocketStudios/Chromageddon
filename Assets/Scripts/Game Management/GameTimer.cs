using UnityEngine;
using UnityEngine.Events;

namespace SRS.GameManagement
{
	public class GameTimer : MonoBehaviour
	{
		public static GameTimer Instance;

		public UnityEvent<float> OnTimeUpdate;

		private float time;
		public float Time
		{
			get
			{
				return time;
			}
			private set
			{
				time = value;
				OnTimeUpdate?.Invoke(time);
			}
		}

		private TimerState state;


		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
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