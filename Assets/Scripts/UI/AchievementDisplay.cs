using UnityEngine;
using SRS.Achievements;
using TMPro;

namespace SRS.UI
{
	public class AchievementDisplay : MonoBehaviour
	{
		[SerializeField] private TMP_Text NameTextBox;
		[SerializeField] private TMP_Text DescriptionTextBox;

		private void OnEnable()
		{
			Achievement.AchievementAwarded += Show;
		}

		private void OnDisable()
		{
			Achievement.AchievementAwarded -= Show;
		}

        private void Show(Achievement achievement)
        {
			NameTextBox.text = achievement.name;
			DescriptionTextBox.text = achievement.Description;
			PlayAnimation();
        }

		private async void PlayAnimation()
		{
			await Awaitable.NextFrameAsync();
		}
    }
}