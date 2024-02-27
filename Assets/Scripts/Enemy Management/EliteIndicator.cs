using UnityEngine;

namespace SRS.EnemyManagement
{
	public class EliteIndicator : MonoBehaviour
	{
		[SerializeField] private EliteIndicatorDatabase database;

		private SpriteRenderer spriteRenderer;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void Draw(int elitifications)
		{
			if(elitifications <= 0)
			{
				return;
			}

			int index = Mathf.Clamp(elitifications-1, 0, database.IndicatorImages.Count-1);

			spriteRenderer.sprite = database.IndicatorImages[index];
			spriteRenderer.color = database.IndicatorColors[index];

			spriteRenderer.enabled = true;
		}

		public void Reset()
		{
			spriteRenderer.enabled = false;
		}
	}
}