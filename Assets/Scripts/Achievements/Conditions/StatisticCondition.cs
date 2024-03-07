using UnityEngine;
using SRS.Statistics;

namespace SRS.Achievements
{
	public class StatisticCondition : Condition
	{
		[SerializeField] private string statistic;

		public override void Initialize()
		{
			StatisticManager.Instance[statistic].OnValueChange += Test;
		}

        public override void Test(float value)
        {
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
    }
}