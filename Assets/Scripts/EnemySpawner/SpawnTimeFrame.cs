using System;

namespace SRS.enemySpawner
{
	[Serializable]
	public class SpawnTimeFrame
	{
		public float StartTime;
		public float EndTime;

		public SpawnTimeFrame(float startTime, float endTime)
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