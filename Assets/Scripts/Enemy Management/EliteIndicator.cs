using UnityEngine;
using UnityEngine.UI;

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

			Debug.Log("elited");

			int index = Mathf.Clamp(elitifications, 0, database.IndicatorImages.Count);

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