using TMPro;
using UnityEngine;

namespace SRS.UI
{
	public class TooltipContainer : MonoBehaviour
	{
		private TMP_Text textBox;

		private void Awake()
		{
			textBox = GetComponentInChildren<TMP_Text>();
		}

		public void Draw(string text, Vector3 position)
		{
			transform.position = (Vector2)position + Vector2.up*0.5f;

			textBox.text = text;
		}
	}
}