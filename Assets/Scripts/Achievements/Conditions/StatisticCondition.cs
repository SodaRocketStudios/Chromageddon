using UnityEngine;
using SRS.Statistics;

namespace SRS.Achievements
{
	[CreateAssetMenu(menuName = "Achievements/Conditions/StatisticCondition", fileName = "New Statistic Condition")]
	public class StatisticCondition : Condition
	{
		[SerializeField] private string statistic;

		protected override void Init()
		{
			StatisticManager.Instance[statistic].OnValueChange += Test;
		}
    }
}