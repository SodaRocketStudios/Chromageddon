using TMPro;
using UnityEngine;

namespace SRS.Achievements
{
	public class AchievementBox : MonoBehaviour
	{
		[SerializeField] private TMP_Text nameTextBox;
		[SerializeField] private TMP_Text descriptionTextBox;

		public void Draw(Achievement achievement)
		{
			nameTextBox.text = achievement.name;
			descriptionTextBox.text = achievement.Description;
		}
	}
}