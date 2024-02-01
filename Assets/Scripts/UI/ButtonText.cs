using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SRS.UI
{
	public class ButtonText : MonoBehaviour
	{
		Button button;
		TMP_Text text;

		private void Awake()
		{
			text = GetComponent<TMP_Text>();
			button = GetComponentInParent<Button>();
		}

		private void Update()
		{
			text.color = button.image.color;
		}
	}
}