using TMPro;
using UnityEngine;

namespace SRS.UI
{
	public class TooltipContainer : MonoBehaviour
	{
		private TMP_Text textBox;

		private void Awake()
		{
			textBox = GetComponent<TMP_Text>();
		}

		public void Draw(string text, Vector3 position)
		{
			transform.position = position;

			textBox.text = text;
		}
	}
}