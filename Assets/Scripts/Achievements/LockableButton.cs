using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using SRS.DataPersistence;
using UnityEngine;
using UnityEngine.UI;

namespace SRS.Achievements
{
	public class LockableButton : MonoBehaviour, IPersist
	{
		private Toggle toggleButton;

		private bool isUnlocked = false;

		[SerializeField] private List<Condition> conditions = new List<Condition>();

		private void Awake()
		{
			toggleButton = GetComponent<Toggle>();
		}

		private void Start()
		{
			foreach (var condition in conditions)
			{
				condition.Initialize();
			}

			Condition.OnMet += CheckConditions;
		}

		private void OnEnable()
		{
			toggleButton.interactable = isUnlocked;

			if(conditions.Count <= 0)
			{
				isUnlocked = true;
				toggleButton.interactable = true;
			}
		}

		private void CheckConditions(Condition triggeringCondition)
		{
			if(isUnlocked == false)
			{
				Condition.OnMet -= CheckConditions;
				return;
			}

			foreach(var condition in conditions)
			{
				if(condition.IsSatisfied == false)
				{
					return;
				}
			}

			isUnlocked = true;
			toggleButton.interactable = true;
		}

        public object CaptureState()
        {
            return isUnlocked;
        }

        public void RestoreState(object state)
        {
            isUnlocked = (bool)(state as JValue);
			toggleButton.interactable = isUnlocked;
        }
    }
}