using System;
using System.Collections.Generic;
using UnityEngine;
using SRS.Extensions.Vector;
using SRS.TopDownCharacterControl.AttackSystem;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class AIBrain : MonoBehaviour
	{
		[SerializeField] private List<State> states = new List<State>();
		private Dictionary<Type, State> stateDict = new Dictionary<Type, State>();
		
		[SerializeField] private float challengeRating;
		public float ChallengeRating { get {return challengeRating;} }

		[SerializeField] private float attackRadius;
		public float AttackRadiusSquared { get; private set;}

		private TopDownCharacterController controller;

		private AttackManager attackManager;

		private Transform target;
		public Transform Target => target;

		private State currentState;

		private void Awake()
		{
			controller = GetComponent<TopDownCharacterController>();

			AttackRadiusSquared = Mathf.Pow(attackRadius, 2);

			attackManager = GetComponent<AttackManager>();

			currentState = states[0];
		}

		private void Update()
		{
			currentState = stateDict[currentState.Execute(transform.position)];
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