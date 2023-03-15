using System;
using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[Serializable]
	public abstract class State : ScriptableObject
	{
		[SerializeField] private float radius;
		public float SquaredRadius => Mathf.Pow(radius, 2);

		public abstract void Enter(AIBrain brain);

		public abstract void Execute(AIBrain brain);

		public abstract void Exit(AIBrain brain);
    }
}