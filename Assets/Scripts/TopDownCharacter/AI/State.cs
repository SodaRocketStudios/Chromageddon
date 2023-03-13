using System;
using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[Serializable]
	public class State
	{
		[SerializeField] private float maxRange;
		protected float squaredRange;
		[SerializeField] private State previousState;
		[SerializeField] private State nextState;

		protected TopDownCharacterController controller;

		protected Transform target;

		public virtual void Initiailize(TopDownCharacterController controller, Transform target) 
		{
			this.controller = controller;
			squaredRange = Mathf.Pow(maxRange, 2);
			this.target = target;
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}

		public void ClearTarget()
		{
			target = null;
		}

		public Type Execute(Vector2 position)
		{
			return this.GetType();
			// return TickState(position);
		}

        // protected abstract Type TickState(Vector2 position);

		protected void MoveTowardTarget(Vector2 position)
		{
			Vector2 direction = ((Vector2)target.position - position);
			controller.MoveDirection = direction;
		}

		protected void LookAtTarget()
		{
			controller.LookTarget = target.position;
		}
    }
}