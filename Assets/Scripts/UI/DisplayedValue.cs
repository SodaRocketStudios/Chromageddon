using UnityEngine;
using TMPro;

namespace SRS.UI
{
	public class DisplayedValue : MonoBehaviour
	{
		[SerializeField] private string preText;
		[SerializeField] private string postText;

		private TMP_Text text;

		private void Awake()
		{
			text = GetComponent<TMP_Text>();
		}

		private void Start()
		{
			text.text = $"{preText}0{postText}";
		}

		public void Draw(float value)
		{
			text.text = $"{preText}{value}{postText}";
		}

		public void Draw(int value)
		{
			text.text = $"{preText}{value}{postText}";
		}
	}
}