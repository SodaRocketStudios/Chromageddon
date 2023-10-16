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

		public bool IsInRange(float time)
		{
			if(time < StartTime) return false;
			if(EndTime < 0) return true;
			if(time <= EndTime) return true;
			return false;
		}
	}
}