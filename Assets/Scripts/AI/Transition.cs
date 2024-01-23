using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.AI
{
	[Serializable]
	public class Transition
	{
		[SerializeField] private List<Criteria> criteria;
		[SerializeField] private State transitionState;

		public State Test(AIBrain brain)
		{
			foreach(Criteria criterion in criteria)
			{
				if(criterion.Check(brain) == false)
				{
					return brain.CurrentState;
				}
			}

			return transitionState;
		}
	}
}