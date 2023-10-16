using UnityEngine;
using UnityEngine.Events;

namespace SRS.LevelSystem
{
	public class CharacterLevel : MonoBehaviour
	{
		[SerializeField] private int baseXPRequirement;

		[SerializeField] private float requirementMultiplier;

		public UnityEvent OnLevelUp;

		public UnityEvent<float> OnCurrentXPChange;
		public UnityEvent<float> OnRequiredXPChange;

		private int level = 1;
		public int Level => level;

		private int requiredXP;
		private int currentXP;
		public int CurrentXP => currentXP;

		private void Awake()
		{
			requiredXP = baseXPRequirement;
		}

		private void Start()
		{
			OnCurrentXPChange?.Invoke(currentXP);
			OnRequiredXPChange?.Invoke(requiredXP);
		}

		public void AddXP(int amount)
		{
			currentXP += amount;

			if(currentXP >= requiredXP)
			{
				LevelUp();
			}

			OnCurrentXPChange?.Invoke(currentXP);
		}

		private void LevelUp()
		{
			level++;
			currentXP -= requiredXP;

			requiredXP = (int)(requirementMultiplier * requiredXP);
			OnLevelUp.Invoke();

			OnRequiredXPChange?.Invoke(requiredXP);
		}
	}
}