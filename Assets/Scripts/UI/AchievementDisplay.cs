using UnityEngine;
using SRS.Achievements;
using TMPro;

namespace SRS.UI
{
	public class AchievementDisplay : MonoBehaviour
	{
		[SerializeField] private TMP_Text NameTextBox;
		[SerializeField] private TMP_Text DescriptionTextBox;

		[SerializeField] private float travelTime;
		[SerializeField] private float dwellTime;

		[SerializeField] private Vector2 moveDistance;

		private Vector3 startPosition;
		private Vector3 showPosition;

		private float timer = 0;

		private RectTransform rectTransform;

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
		}

		private void Start()
		{
			startPosition = rectTransform.anchoredPosition;
			showPosition = startPosition + (Vector3)moveDistance;
		}

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
			timer = 0;

			float t;

			while(timer < travelTime)
			{
				timer += Time.deltaTime;
				t = timer / travelTime;
				rectTransform.anchoredPosition = Vector3.Lerp(startPosition, showPosition, t);
				await Awaitable.NextFrameAsync();
			}

			timer = 0;

			while(timer < dwellTime)
			{
				timer += Time.deltaTime;
				await Awaitable.NextFrameAsync();
			}

			timer = 0;

			while(timer < travelTime)
			{
				timer += Time.deltaTime;
				t = timer / travelTime;
				rectTransform.anchoredPosition = Vector3.Lerp(showPosition, startPosition, t);
				await Awaitable.NextFrameAsync();
			}
		}
    }
}