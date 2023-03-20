using UnityEngine;

namespace SRS.LevelSystem
{
	public class CharacterLevel : MonoBehaviour
	{
		[SerializeField] private int baseXPRequirement;

		private int level = 1;
		public int Level => level;

		private int requiredXP;
		private int currentXP;
		public int CurrentXP => currentXP;

		private void Awake()
		{
			requiredXP = baseXPRequirement;
		}

		public void AddXP(int amount)
		{
			currentXP += amount;

			if(currentXP >= requiredXP)
			{
				LevelUp();
			}
		}

		private void LevelUp()
		{
			level++;
			currentXP -= requiredXP;
			requiredXP *= 2;
		}
	}
}