using UnityEngine;
using SRS.Statistics;
using TMPro;

namespace SRS.UI
{
	public class StatisticDisplay : MonoBehaviour
	{
		[SerializeField] private string statistic;

		[SerializeField] private string preText;
		[SerializeField] private string postText;

		private TMP_Text textComponent;

		private void Awake()
		{
			textComponent = GetComponent<TMP_Text>();
		}

		private void OnEnable()
		{
			Draw();
		}

        public void Draw()
        {
			string value  = StatisticManager.Instance[statistic].GetFormattedValue();
			textComponent.text = $"{preText}{value}{postText}";
        }
    }
}