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

		[SerializeField] private string unlockCriteria;
		[SerializeField] private string description;

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

		private void OnDestroy()
		{
			Condition.OnMet -= CheckConditions;
		}

		public string GetDescription()
		{
			return isUnlocked?description:unlockCriteria;
		}

		private void CheckConditions(Condition triggeringCondition)
		{
			if(isUnlocked == true)
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

			Debug.Log("Satisfied", gameObject);

			PersistenceSystem.Instance.Save("Save");

			isUnlocked = true;
			toggleButton.interactable = true;
		}

        public object CaptureState()
        {
            return isUnlocked;
        }

        public void RestoreState(object state)
        {
			Debug.Log("Restore");
            isUnlocked = (bool)(state as JValue);

			if(toggleButton != null)
			{
				toggleButton.interactable = isUnlocked;
			}
        }
    }
}