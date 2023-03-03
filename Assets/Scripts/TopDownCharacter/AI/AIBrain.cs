using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class AIBrain : MonoBehaviour
	{
		[SerializeField] private float challengeRating;
		public float ChallengeRating { get {return challengeRating;} }

		[SerializeField] private float detectionRadius;
		public float DetectionRadiusSquared => detectionRadius;

		[SerializeField] private float attackRadius;
		public float AttackRadiusSquared => attackRadius;

		[SerializeField] private float fleeRadius;
		public float FleeRadiusSquared => fleeRadius;

		private Transform target;
		public Transform Target => target;

		private AIState currentState;

		private Dictionary<Type, AIState> states;

		private void Awake()
		{
			states = new Dictionary<Type, AIState>()
			{
				{typeof(RoamState), new RoamState(gameObject)},
				{typeof(ChaseState), new ChaseState(gameObject)},
				{typeof(AttackState), new AttackState(gameObject)},
				{typeof(FleeState), new FleeState(gameObject)}
			};

			detectionRadius *= detectionRadius;
			attackRadius *= attackRadius;
			fleeRadius *=fleeRadius;
		}

		private void OnEnable()
		{
			currentState = states[typeof(RoamState)];
		}

		private void Update()
		{
			Type nextState = currentState.Tick();

			if(states[nextState] != currentState)
			{
				currentState.Exit();
			}

			currentState = states[nextState];
		}

		private void OnDisable()
		{
			currentState.Exit();
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}

		public void ClearTarget()
		{
			target = null;
		}
	}
}