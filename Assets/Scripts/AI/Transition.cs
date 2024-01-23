using System;
using UnityEngine;

namespace SRS.AI
{
	[Serializable]
	public class Transition
	{
		[SerializeField] private Criteria decision;
		[SerializeField] private State trueState;

		public State Test(AIBrain brain)
		{
			if(decision.Check(brain) == true)
			{
				if(trueState == null)
				{
					return trueState;
				}
			}
			
			return brain.CurrentState;
		}
	}
}