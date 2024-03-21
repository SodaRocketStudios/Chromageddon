using System.Collections.Generic;
using UnityEngine;
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

		private Queue<string[]> achievements;

		private Vector3 startPosition;
		private Vector3 showPosition;

		private float timer = 0;

		private bool isShowing;

		private RectTransform rectTransform;

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
			startPosition = rectTransform.anchoredPosition;
			showPosition = startPosition + (Vector3)moveDistance;
		}

        public void Show(string name, string description)
        {
			if(isShowing)
			{
				achievements.Enqueue(new string[2]{name, description});
				return;
			}

			NameTextBox.text = name;
			DescriptionTextBox.text = description;
			PlayAnimation();
        }

		private async void PlayAnimation()
		{
			isShowing = true;
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
			
			isShowing = false;

			if(achievements.Count > 0)
			{
				string[] info = achievements.Dequeue();
				Show(info[0], info[1]);
			}
		}
    }
}