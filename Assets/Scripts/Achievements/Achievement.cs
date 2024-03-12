using System;
using UnityEngine;
using SRS.DataPersistence;

namespace SRS.Achievements
{
	[CreateAssetMenu(menuName = "Achievements/Achievement", fileName = "New Achievement")]
	public class Achievement : ScriptableObject, IPersist
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

			PersistenceSystem.Instance.Save("Save");
		}

        public object CaptureState()
        {
            return hasBeenAwarded;
        }

        public void RestoreState(object state)
        {
            bool data = (bool)state;

			hasBeenAwarded = data;
        }
    }
}