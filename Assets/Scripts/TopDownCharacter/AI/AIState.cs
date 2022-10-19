using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	public abstract class AIState
	{
		public Vector2 Target{get; protected set;}

		protected Transform transform;

		public virtual void Enter(Transform transform)
		{
			this.transform = transform;
		}
		public abstract void Execute();
	}
}