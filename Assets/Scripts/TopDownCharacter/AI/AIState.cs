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

		private CharacterStats stats;

		public AIState(GameObject self)
		{
			this.self = self;

			brain = self.GetComponent<AIBrain>();
			controller = self.GetComponent<TopDownCharacterController>();
			attackManager = self.GetComponent<AttackManager>();
			stats = self.GetComponent<CharacterStats>();

			Enter();
		}

		virtual protected void Enter() {}

		abstract public Type Execute();

		virtual public void Exit()
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