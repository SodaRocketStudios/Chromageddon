using System;
using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[Serializable]
	public abstract class State
	{
		[SerializeField] private float radius;
		public float SquaredRadius { get; private set; }

		public abstract void Enter(AIBrain brain);

		public abstract void Execute(AIBrain brain);

		public abstract void Exit(AIBrain brain);
    }
}