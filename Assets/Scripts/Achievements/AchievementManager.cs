using System.Collections.Generic;
using SRS.DataPersistence;
using SRS.UI;
using SRS.Utils;
using UnityEngine;

namespace SRS.Achievements
{
	public class AchievementManager : MonoBehaviour, IPersist
	{
		[SerializeField] private Achievement[] achievements;

		[SerializeField] private AchievementDisplay display;

        private void Start()
		{
			foreach(Achievement achievement in achievements)
			{
				achievement.Initialize();
			}
		}

		private void OnEnable()
		{
			Achievement.AchievementAwarded += ShowAchievement;
		}


        private void OnDisable()
		{
			Achievement.AchievementAwarded -= ShowAchievement;
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
			Dictionary<string, object> data = state.ToDictionary();

            foreach(Achievement achievement in achievements)
			{
				if(data.ContainsKey(achievement.name))
				{
					achievement.RestoreState(data[achievement.name]);
				}
			}
        }

        public void ShowAchievement(Achievement achievement)
        {
            display.Show(achievement.name, achievement.Description);
        }
	}
}