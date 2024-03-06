using System;
using UnityEngine;

namespace SRS.Achievements
{
	public class Achievement : ScriptableObject
	{
		public string Name;
		public string Description;

		public static Action<Achievement> AchievementAwarded;

		[SerializeField] private Condition[] conditions;

		private bool hasBeenAwarded = false;

		public void CheckConditions()
		{
			foreach(Condition condition in conditions)
			{
				if(condition.IsSatisfied == false)
				{
					return;
				}
			}

			Award();
		}

		private void Award()
		{
			hasBeenAwarded = true;
			AchievementAwarded?.Invoke(this);

			// TODO -- save this achievement.
		}

		// TODO --  add save and load.
	}
}