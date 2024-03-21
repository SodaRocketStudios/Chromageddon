using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SRS.Achievements
{
	public class AchievementBox : MonoBehaviour
	{
		[SerializeField] private TMP_Text nameTextBox;
		[SerializeField] private TMP_Text descriptionTextBox;
		[SerializeField] private Image checkMark;

		public void Draw(Achievement achievement)
		{
			nameTextBox.text = achievement.name;
			descriptionTextBox.text = achievement.Description;

			Debug.Log($"{achievement.name}: {achievement.IsAwarded}");

			if(achievement.IsAwarded)
			{
				checkMark.enabled = true;
			}
			else
			{
				checkMark.enabled = false;
			}
		}
	}
}