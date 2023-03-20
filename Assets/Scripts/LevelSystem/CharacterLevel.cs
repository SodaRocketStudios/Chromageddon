using UnityEngine;

namespace SRS.LevelSystem
{
	public class CharacterLevel : MonoBehaviour
	{
		private int level;
		public int Level => level;

		private int requiredXP;
		private int currentXP;

		private void OnLevelUp()
		{
			level++;
			currentXP = 0;
			// calculate required xp;
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if()
		}
	}
}