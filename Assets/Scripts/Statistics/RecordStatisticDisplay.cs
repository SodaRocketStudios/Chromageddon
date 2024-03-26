using TMPro;
using UnityEngine;

namespace SRS.Statistics
{
	public class RecordStatisticDisplay : MonoBehaviour
	{
		[SerializeField] private string statName;
		[SerializeField] private string alternativeStatName;

		private TMP_Text textBox;

		private void Awake()
		{
			textBox = GetComponent<TMP_Text>();
		}

		private void OnEnable()
		{
			Draw();
		}

		private void Draw()
		{
			string name = string.IsNullOrEmpty(alternativeStatName) ? statName : alternativeStatName;
			textBox.text = $"{name}: {RecordStatisticManager.Instance[statName].Value:N0}";
		}
	}
}