using UnityEngine;
using SRS.Statistics;

namespace SRS.Achievements
{
	[CreateAssetMenu(menuName = "Achievements/Conditions/StatisticCondition", fileName = "New Statistic Condition")]
	public class StatisticCondition : Condition
	{
		[SerializeField] private string statistic;

        public override void Test(float value)
        {
			Debug.Log("Testing Condition");
			switch(comparison)
			{
				case ComparisonOperator.Less:

					if(value < targetValue)
					{
						IsSatisfied = true;
						break;
					}

					IsSatisfied = false;

					break;
				case ComparisonOperator.LessOrEqual:
								
					if(value <= targetValue)
					{
						IsSatisfied = true;
						break;
					}

					IsSatisfied = false;

					break;
				case ComparisonOperator.Equal:
								
					if(value == targetValue)
					{
						IsSatisfied = true;
						break;
					}

					IsSatisfied = false;

					break;
				case ComparisonOperator.GreaterOrEqual:
								
					if(value >= targetValue)
					{
						IsSatisfied = true;
						break;
					}

					IsSatisfied = false;

					break;
				case ComparisonOperator.Greater:
								
					if(value > targetValue)
					{
						IsSatisfied = true;
						break;
					}

					IsSatisfied = false;

					break;
			}
        }

		protected override void Init()
		{
			StatisticManager.Instance[statistic].OnValueChange += Test;
		}
    }
}