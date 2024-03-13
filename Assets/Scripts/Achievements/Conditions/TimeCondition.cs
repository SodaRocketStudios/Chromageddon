using UnityEngine;
using SRS.GameManagement;

namespace SRS.Achievements
{
	[CreateAssetMenu(menuName = "Achievements/Conditions/Time Condition", fileName = "New Time Condition")]
    public class TimeCondition : Condition
    {
        protected override void Init()
        {
			GameTimer.Instance.OnTimeUpdate.AddListener(Test);
        }
    }
}