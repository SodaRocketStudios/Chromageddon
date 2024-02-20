using UnityEngine;
using TMPro;

namespace SRS.UI
{
	public class DisplayedValue : MonoBehaviour
	{
		[SerializeField] private string preText;
		[SerializeField] private string postText;
		[SerializeField] private int decimalPlaces = 1;

		private TMP_Text textComponent;

		private void Awake()
		{
			textComponent = GetComponent<TMP_Text>();
		}

		private void Start()
		{
			textComponent.text = $"{preText}0{postText}";
		}

		public void Draw(float value)
		{
			textComponent.text = $"{preText}{value.ToString("N" + decimalPlaces)}{postText}";
		}

		public void Draw(int value)
		{
			textComponent.text = $"{preText}{value.ToString("N" + decimalPlaces)}{postText}";
		}
	}
}