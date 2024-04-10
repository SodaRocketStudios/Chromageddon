using System.Collections.Generic;
using System.Text;
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

		public string GetUnlockCriteria()
		{
			StringBuilder criteriaBuilder = new();

			foreach (var condition in conditions)
			{
				criteriaBuilder.AppendLine(condition.name);
			}

			return criteriaBuilder.ToString();
		}

		private void CheckConditions(Condition triggeringCondition)
		{
			Debug.Log("Checking Conditions", gameObject);
			if(isUnlocked == true)
			{
				Condition.OnMet -= CheckConditions;
				return;
			}

			foreach(var condition in conditions)
			{
				if(condition.IsSatisfied == false)
				{
					Debug.Log("Not Satisfied", gameObject);
					return;
				}
			}

			Debug.Log("Satisfied", gameObject);

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