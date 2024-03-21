using System;
using UnityEngine;

namespace SRS.Achievements
{
	public class AchievementMenu : MonoBehaviour
	{
		[SerializeField] private AchievementManager achievementManager;

		[SerializeField] private GameObject achievementBox;

		[SerializeField] private Transform contianer;

		private bool hasBeenDrawn;

		private void OnEnable()
		{
			if(hasBeenDrawn == false)
			{
				Draw();
			}
		}

		public void Draw()
		{
			Achievement[] sortedAchievements = achievementManager.Achievements;
			Array.Sort(sortedAchievements, delegate(Achievement a, Achievement b) { return a.name.CompareTo(b.name); });

			foreach(Achievement achievement in sortedAchievements)
			{
				AchievementBox box = Instantiate(achievementBox, contianer).GetComponent<AchievementBox>();
				box.Draw(achievement);
			}

			hasBeenDrawn = true;
		}
	}
}