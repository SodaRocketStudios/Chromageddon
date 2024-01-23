using UnityEngine;

namespace SRS.AI
{
	[CreateAssetMenu(fileName = "New Outside Range Criteria", menuName = "Enemies/AI/Criteria/Outside Range Criteria")]
	public class OutsideRangeCriteria : Criteria
	{
		[SerializeField] private float range;
		private float rangeSquared = -1;

        public override bool Check(AIBrain brain)
        {
			if(rangeSquared < 0)
			{
				rangeSquared = Mathf.Pow(range, 2);
			}

            if(brain.TargetDistanceSquared >= rangeSquared)
			{
				return true;
			}

			return false;
        }
	}
}