using System;
using UnityEngine;

namespace SRS.Achievements
{
	public class Achievement : ScriptableObject
	{
		[SerializeField] private new string name;
		public string Name
		{
			get => name;
		}

		[SerializeField] private string description;
		public string Description
		{
			get => description;
		}

		public static Action<Achievement> AchievementAwarded;

		[SerializeField] private Condition[] conditions;

		private bool hasBeenAwarded = false;

		public void Initialize()
		{
			Condition.OnMet += CheckConditions;
			Load();
		}

		public void CheckConditions(Condition triggeringCondition)
		{
			if(hasBeenAwarded)
			{
				return;
			}

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

			Condition.OnMet -= CheckConditions;

			Save();
		}

		private void Save()
		{
			// TODO -- Save
		}

		private void Load()
		{
			// TODO -- Load
		}
	}
}