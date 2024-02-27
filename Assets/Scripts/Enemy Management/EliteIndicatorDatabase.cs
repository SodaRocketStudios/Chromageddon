using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SRS.EnemyManagement
{
	[CreateAssetMenu(menuName = "Enemies/IndicatorDatabase", fileName = "New Elite Indicator Database")]
	public class EliteIndicatorDatabase : ScriptableObject
	{
		[SerializeField] private List<Sprite> indicatorImages;
		public List<Sprite> IndicatorImages
		{
			get => indicatorImages;
		}

		[SerializeField] private List<Color> indicatorColors;
		public List<Color> IndicatorColors
		{
			get => indicatorColors;
		}
	}
}