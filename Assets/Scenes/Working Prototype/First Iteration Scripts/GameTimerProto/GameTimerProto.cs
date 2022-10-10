using UnityEngine;

namespace SRS.GameTimeProto
{
	public class GameTimerProto : MonoBehaviour
	{
		public static GameTimerProto Instance;

		public float currentTime{get; private set;}
		private TimerState state;


		private void Awake()
		{
			if(GameTimerProto.Instance == null)
			{
				Instance = this;
			}
			else if(GameTimerProto.Instance != this)
			{
				Destroy(gameObject);
			}

			state = TimerState.Stopped;
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
					currentTime += Time.deltaTime;
					break;
				case TimerState.Paused:
					break;
				case TimerState.Stopped:
					currentTime = 0;
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