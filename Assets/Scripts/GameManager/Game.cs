using UnityEngine;

namespace SRS.GameManager
{
	public class Game : MonoBehaviour
	{
		public static Game Instance;

		public bool Paused{get; private set;} = false;

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

		public void Pause()
		{
			Time.timeScale = 0;
			Paused = true;
		}

		public void Play()
		{
			Time.timeScale = 1;
			Paused = false;
		}
	}
}