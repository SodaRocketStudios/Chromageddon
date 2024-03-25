using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace SRS.Statistics
{
	[Serializable]
	public class StatisticRecord
	{
		public string Name;

		[SerializeField] private string statistic;

		private float recordValue;

		public float Value
		{
			get => recordValue;
		}

		public void Initialize()
		{
			StatisticManager.Instance[statistic].OnValueChange += Test;
		}

        public void Test(float testValue)
		{
			if(testValue > recordValue)
			{
				Debug.Log("Record");
				recordValue = testValue;
			}
		}

        public object CaptureState()
        {
            return recordValue;
        }

        public void RestoreState(object state)
        {
			JValue jValue = state as JValue;
			
            recordValue = (float)jValue;
        }
	}
}