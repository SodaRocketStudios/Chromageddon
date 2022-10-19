using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	public abstract class AIState
	{
		public Vector2 Target{get; protected set;}

		protected Transform transform;

		public abstract void Enter(Transform transform);
		public abstract void Execute();
	}
}