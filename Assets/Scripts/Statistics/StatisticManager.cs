using System.Collections.Generic;
using UnityEngine;
using SRS.Utils;
using SRS.DataPersistence;

namespace SRS.Statistics
{
	public class StatisticManager : MonoBehaviour, IPersist
	{
		public static StatisticManager Instance;

		private Dictionary<string, Statistic> statistics = new();

		public Statistic this[string name]
		{
			get
			{
				if(statistics.ContainsKey(name))
				{
					return statistics[name];
				}

				// Debug.LogWarning($"Statistic {name} not found, adding to dictionary");
				AddStatistic(name);

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
		}

		public bool AddStatistic(string name, float defaultValue = 0, int decimalPlaces = 0, bool isPersistent = false)
		{
			if(statistics.ContainsKey(name))
			{
				Debug.LogWarning($"Statistic {name} already exists");
				return false;
			}

			statistics[name] = new(name, defaultValue, decimalPlaces, isPersistent);

			return true;
		}

        public object CaptureState()
        {
            Dictionary<string, object> data = new();

            foreach(Statistic statistic in statistics.Values)
			{
				data.Add(statistic.Name, statistic.CaptureState());
			}

			return data;
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> data = state.ToDictionary();

			foreach(string name in data.Keys)
			{
				if(statistics.ContainsKey(name) == false)
				{
					AddStatistic(name);
				}

				statistics[name].RestoreState(data[name]);
			}
        }
    }
}