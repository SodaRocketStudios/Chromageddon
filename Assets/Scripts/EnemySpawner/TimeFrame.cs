using System;

namespace SRS.EnemySpawner
{
	[Serializable]
	public class TimeFrame
	{
		public float StartTime;
		public float EndTime;

		public TimeFrame(float startTime, float endTime)
		{
			this.StartTime = startTime;
			this.EndTime = endTime;
		}

		public bool isInRange(float time)
		{
			return time >= StartTime && time <= EndTime;
		}
	}
}