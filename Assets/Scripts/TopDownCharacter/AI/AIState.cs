using System;
using UnityEngine;
using SRS.TopDownCharacterControl.AttackSystem;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl.AI
{
	public abstract class AIState
	{
		protected GameObject self;

		protected AIBrain brain;
		protected TopDownCharacterController controller;
		protected AttackManager attackManager;

		private CharacterData data;

		public AIState(GameObject self)
		{
			this.self = self;

			brain = self.GetComponent<AIBrain>();
			controller = self.GetComponent<TopDownCharacterController>();
			attackManager = self.GetComponent<AttackManager>();
			data = self.GetComponent<CharacterData>();

			Enter();
		}

		protected virtual void Enter() {}

		public Type Tick()
		{
			if(brain.Target == null)
			{
				return typeof(RoamState);
			}

			return Execute();
		}

		protected abstract Type Execute();

		public virtual void Exit()
		{
			controller.MoveDirection = Vector2.zero;
		}

		protected void MoveTowardTarget(Vector2 moveTarget)
		{
			Vector2 direction = (moveTarget - (Vector2)self.transform.position).normalized;
			controller.MoveDirection = direction;
		}

		protected void LookAtTarget(Vector2 lookTarget)
		{
			controller.LookTarget = lookTarget;
		}
	}
}