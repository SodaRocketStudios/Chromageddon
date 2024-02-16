using System.Collections.Generic;
using UnityEngine;

namespace SRS.Statistics
{
	public class StatisticManager : MonoBehaviour
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

				Debug.LogWarning($"Statistic {name} not found, adding to dictionary");
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

		public void AddStatistic(string name, float defaultValue = 0, int decimalPlaces = 0)
		{
			if(statistics.ContainsKey(name))
			{
				Debug.LogWarning($"Statistic {name} already exists");
				return;
			}

			statistics[name] = new(name, defaultValue, decimalPlaces);
		}
	}
}