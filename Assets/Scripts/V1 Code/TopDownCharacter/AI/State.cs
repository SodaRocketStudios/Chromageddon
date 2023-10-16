using System;
using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[Serializable]
	public abstract class State : ScriptableObject
	{
		[SerializeField] private float radius;
		private float squaredRadius;
		private bool isSquared = false;
		public float SquaredRadius
		{
			get
			{
				if(isSquared == false)
				{
					squaredRadius = Mathf.Pow(radius, 2);
					isSquared = true;
				}
				
				return squaredRadius;
			}
		}

		public abstract void Enter(AIBrain brain);

		public abstract void Execute(AIBrain brain);

		public abstract void Exit(AIBrain brain);
    }
}