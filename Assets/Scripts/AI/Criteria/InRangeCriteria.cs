using UnityEngine;

namespace SRS.AI
{
	[CreateAssetMenu(fileName = "New In Range Criteria", menuName = "Enemies/AI/Criteria/In Range Criteria")]
    public class InRangeCriteria : Criteria
    {
		[SerializeField] private float range;
		private float rangeSquared = -1;

        public override bool Check(AIBrain brain)
        {
			if(rangeSquared < 0)
			{
				rangeSquared = Mathf.Pow(range, 2);
			}

            if(brain.TargetDistanceSquared <= rangeSquared)
			{
				return true;
			}

			return false;
        }
    }
}