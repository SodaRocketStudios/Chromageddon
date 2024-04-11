using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using SRS.DataPersistence;
using UnityEngine;
using UnityEngine.UI;

namespace SRS.Achievements
{
	public class LockableButton : MonoBehaviour, IPersist
	{
		[SerializeField] private List<Condition> conditions = new List<Condition>();

		[SerializeField] private string unlockCriteria;
		[SerializeField] private string description;

		public Action OnStateChange;

		private Toggle toggleButton;

		private bool isUnlocked = false;

		public bool IsUnlocked
		{
			get => isUnlocked;
			private set
			{
				isUnlocked = value;
				OnStateChange?.Invoke();
			}
		}

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
			OnStateChange?.Invoke();
			
			if(conditions.Count <= 0)
			{
				IsUnlocked = true;
			}

			toggleButton.interactable = IsUnlocked;
		}

		private void OnDestroy()
		{
			Condition.OnMet -= CheckConditions;
		}

		public string GetDescription()
		{
			return IsUnlocked?description:unlockCriteria;
		}

		private void CheckConditions(Condition triggeringCondition)
		{
			if(IsUnlocked == true)
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

			IsUnlocked = true;
			toggleButton.interactable = true;
		}

        public object CaptureState()
        {
            return IsUnlocked;
        }

        public void RestoreState(object state)
        {
			Debug.Log("Restore");
            IsUnlocked = (bool)(state as JValue);

			if(toggleButton != null)
			{
				toggleButton.interactable = IsUnlocked;
			}
        }
    }
}