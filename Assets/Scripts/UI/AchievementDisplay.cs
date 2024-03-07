using UnityEngine;
using SRS.Achievements;
using System;

namespace SRS.UI
{
	public class AchievementDisplay : MonoBehaviour
	{
		private void Start()
		{
			Achievement.AchievementAwarded += Show;
		}

        private void Show(Achievement achievement)
        {
			Debug.Log(achievement.Description);
        }
    }
}