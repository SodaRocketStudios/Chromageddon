using System.Collections.Generic;
using SRS.DataPersistence;
using UnityEngine;

namespace SRS.Achievements
{
	public class AchievementManager : MonoBehaviour, IPersist
	{
		[SerializeField] private Achievement[] achievements;

        private void Start()
		{
			foreach(Achievement achievement in achievements)
			{
				achievement.Initialize();
			}
		}

        public object CaptureState()
        {
			Dictionary<string, object> data = new();
            foreach(Achievement achievement in achievements)
			{
				data[achievement.name] = achievement.CaptureState();
			}

			return data;
        }

        public void RestoreState(object state)
        {
			Dictionary<string, object> data = state as Dictionary<string, object>;

            foreach(Achievement achievement in achievements)
			{
				if(data.ContainsKey(achievement.name))
					achievement.RestoreState(data[achievement.name]);
			}
        }
	}
}