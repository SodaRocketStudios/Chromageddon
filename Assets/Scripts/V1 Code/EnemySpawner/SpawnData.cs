using System.Collections.Generic;
using UnityEngine;

namespace SRS.EnemySpawner
{
	public class SpawnData : MonoBehaviour
	{
		[SerializeField] private List<TimeFrame> spawnTimes = new List<TimeFrame>();
		[SerializeField] private int cost;
		public int Cost
		{
			get
			{
				return cost;
			}
		}

		public bool CanSpawn(float time)
		{
			foreach(TimeFrame timeFrame in spawnTimes)
			{
				if(timeFrame.IsInRange(time))
				{
					return true;
				}
			}

			return false;
		}
	}
}