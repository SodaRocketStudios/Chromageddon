using System.Collections.Generic;
using UnityEngine;
using SRS.TopDownCharacterControl.AttackSystem;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class AIBrain : MonoBehaviour
	{
		[SerializeField] private List<State> states = new List<State>();

		private TopDownCharacterController controller;
		public TopDownCharacterController Controller => controller;

		private AttackManager attackManager;
		public AttackManager AttackManager => attackManager;

		private Transform target;
		public Transform Target => target;

		private int currentStateIndex;

		private void Awake()
		{
			controller = GetComponent<TopDownCharacterController>();

			attackManager = GetComponent<AttackManager>();
		}

		private void Update()
		{
			if(states[currentStateIndex] != null)
			{
				float distanceToTarget = VectorExtensions.SquareDistance(target.position, transform.position);
				if(distanceToTarget > states[currentStateIndex].SquaredRadius)
				{
					currentStateIndex += -1;
					currentStateIndex = Mathf.Max(0, currentStateIndex);
				}
				else if(distanceToTarget < states[currentStateIndex - 1].SquaredRadius)
				{
					currentStateIndex += 1;
					currentStateIndex = Mathf.Min(states.Count - 1, currentStateIndex);
				}

				states[currentStateIndex].Execute(this);
			}
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}

		public void ClearTarget()
		{
			target = null;
		}

		public void MoveToward(Vector2 position)
		{
			controller.MoveDirection = position - (Vector2)transform.position;
		}

		public void LookAt(Vector2 position)
		{
			controller.LookTarget = position;
		}
	}
}