using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class AIBrain : MonoBehaviour
	{
		[SerializeField] private float detectionRadius;
		public float DetectionRadius => detectionRadius;

		[SerializeField] private float attackRadius;
		public float AttackRadius => attackRadius;

		[SerializeField] private float fleeRadius;
		public float FleeRadius => fleeRadius;

		private Transform target;
		public Transform Target => target;

		private CircleCollider2D detectionRangeCollider;

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

        private void Start()
		{
			detectionRangeCollider = gameObject.AddComponent<CircleCollider2D>();
			detectionRangeCollider.radius = detectionRadius;
			detectionRangeCollider.isTrigger = true;
		}

		private void OnEnable()
		{
			currentState = states[typeof(RoamState)];
		}

		private void Update()
		{
			Type nextState = currentState.Execute();

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

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				target = other.transform;
				currentState = states[typeof(ChaseState)];
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				target = null;
				currentState = states[typeof(RoamState)];
			}
		}
	}
}