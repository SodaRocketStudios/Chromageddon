using System;
using UnityEngine;

namespace SRS.Achievements
{
	[CreateAssetMenu(menuName = "Achievements/Achievement", fileName = "New Achievement")]
	public class Achievement : ScriptableObject
	{
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
			hasBeenAwarded = false;
			
			Load();

			if(hasBeenAwarded)
			{
				return;
			}

			Condition.OnMet += CheckConditions;
			
			foreach(Condition condition in conditions)
			{
				condition.Initialize();
			}
		}

		public void CheckConditions(Condition triggeringCondition)
		{
			Debug.Log("Checking Achievement");
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
			Debug.Log("Awarded");
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