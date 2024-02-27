using UnityEngine;
using UnityEngine.UI;

namespace SRS.EnemyManagement
{
	public class EliteIndicator : MonoBehaviour
	{
		[SerializeField] private EliteIndicatorDatabase database;

		private Image image;

		private void Awake()
		{
			image = GetComponent<Image>();
		}

		public void Draw(int elitifications)
		{
			if(elitifications <= 0)
			{
				return;
			}

			int index = Mathf.Clamp(elitifications, 0, database.IndicatorImages.Count);

			image.sprite = database.IndicatorImages[index];
			image.color = database.IndicatorColors[index];

			image.enabled = true;
		}

		public void Reset()
		{
			image.enabled = false;
		}
	}
}