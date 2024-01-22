using UnityEngine;

namespace SRS.AI
{
	[CreateAssetMenu(fileName = "New Range Decision", menuName = "Enemies/AI/Decisions/Range Decision")]
    public class RangeDecision : Decision
    {
		[SerializeField] private float range;
		private float rangeSquared = -1;

        public override bool Decide(AIBrain brain)
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