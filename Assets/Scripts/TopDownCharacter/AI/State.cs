using System;
using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[Serializable]
	public abstract class State
	{
		[SerializeField] private float maxRange;
		protected float squaredRange;

		private State previousState;
		private State nextState;

		public abstract void Enter(AIBrain brain);

		public abstract State Execute(AIBrain brain);

		public abstract void Exit(AIBrain brain);
    }
}