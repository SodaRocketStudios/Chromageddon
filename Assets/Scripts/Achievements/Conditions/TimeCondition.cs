using SRS.GameManagement;

namespace SRS.Achievements
{
    public class TimeCondition : Condition
    {
        protected override void Init()
        {
			GameTimer.Instance.OnTimeUpdate.AddListener(Test);
        }
    }
}