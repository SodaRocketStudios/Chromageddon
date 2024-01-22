using System;
using UnityEngine;

namespace SRS.AI
{
	// [CreateAssetMenu(fileName = "New Transition", menuName = "Enemies/AI/Transition")]
	[Serializable]
	public class Transition
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