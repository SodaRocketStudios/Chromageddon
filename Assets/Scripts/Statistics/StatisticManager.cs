using System.Collections.Generic;
using UnityEngine;

namespace SRS.Statistics
{
	public class StatisticManager : MonoBehaviour
	{
		public static StatisticManager Instance;

		[SerializeField] private List<Statistic> statisticList;
		private Dictionary<string, Statistic> statistics;

		public Statistic this[string name]
		{
			get
			{
				if(!initialized)
				{
					Initialize();
				}

				if(statistics.ContainsKey(name))
				{
					return statistics[name];
				}

				Debug.LogWarning($"Statistic {name} not found, adding to dictionary");
				statistics[name] = new Statistic(name);
				
				return statistics[name];
			}
		}

		private bool initialized;

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

			Initialize();
		}

		private void Initialize()
		{
			foreach(Statistic statistic in statisticList)
			{
				statistics[statistic.Name] = statistic;
			}

			initialized = true;
		}
	}
}