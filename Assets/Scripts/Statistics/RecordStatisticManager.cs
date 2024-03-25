using System.Collections.Generic;
using UnityEngine;
using SRS.DataPersistence;
using SRS.Utils;

namespace SRS.Statistics
{
	public class RecordStatisticManager : MonoBehaviour, IPersist
	{
		public static RecordStatisticManager Instance;

		[SerializeField] private StatisticRecord[] recordStatistics;

		private Dictionary<string, StatisticRecord> statistics = new();

		public StatisticRecord this[string name]
		{
			get
			{
				return statistics[name];
			}
		}

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

			foreach(StatisticRecord record in recordStatistics)
			{
				statistics.Add(record.Name, record);
			}
		}

		private void Start()
		{
			foreach(StatisticRecord record in recordStatistics)
			{
				record.Initialize();
			}
		}

        public object CaptureState()
        {
			Dictionary<string, object> stateDictionary = new();

            foreach(StatisticRecord record in recordStatistics)
			{
				stateDictionary[record.Name] = record.CaptureState();
			}

			return stateDictionary;
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> stateDictionary = state.ToDictionary();

			foreach(StatisticRecord record in recordStatistics)
			{
				if(stateDictionary.ContainsKey(record.Name))
				{
					record.RestoreState(stateDictionary[record.Name]);
				}
			}
        }
    }
}