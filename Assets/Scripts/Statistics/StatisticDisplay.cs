using UnityEngine;
using TMPro;

namespace SRS.Statistics
{
	public class StatisticDisplay : MonoBehaviour
	{
		[SerializeField] private string statName;
		[SerializeField] private string alternativeStatName;

		private TMP_Text textBox;

		private void OnEnable()
		{
			Draw();
		}

		private void Draw()
		{
			string name = string.IsNullOrEmpty(alternativeStatName) ? statName : alternativeStatName;
			textBox.text = $"{name}: {StatisticManager.Instance[statName].Value}";
		}
	}
}