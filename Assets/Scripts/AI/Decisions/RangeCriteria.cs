using UnityEngine;

namespace SRS.AI
{
	[CreateAssetMenu(fileName = "New Range Criteria", menuName = "Enemies/AI/Decisions/Range Criteria")]
    public class RangeCriteria : Criteria
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