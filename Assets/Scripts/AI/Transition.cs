using UnityEngine;

namespace SRS.AI
{
	public class Transition : ScriptableObject
	{
		[SerializeField] private Decision decision;
		[SerializeField] private State trueState;
		[SerializeField] private State falseState;

		public void Test(AIBrain brain)
		{
			if(decision.Decide(brain) == true)
			{
				if(trueState == null)
				{
					return;
				}
				brain.ChangeState(trueState);
			}
			else
			{
				if(falseState == null)
				{
					return;
				}
				brain.ChangeState(falseState);
			}
		}
	}
}