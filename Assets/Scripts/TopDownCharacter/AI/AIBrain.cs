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

		private int currentStateIndex = 0;

		private void Awake()
		{
			controller = GetComponent<TopDownCharacterController>();

			attackManager = GetComponent<AttackManager>();

			for(int i = 0; i < states.Count; i++)
			{
				states[i] = Object.Instantiate(states[i]);
			}

			states[0].Enter(this);
		}

		private void Update()
		{
			if(states[currentStateIndex] == null)
			{
				return;
			}

			if(target != null)
			{
				float squaredDistanceToTarget = VectorExtensions.SquareDistance(target.position, transform.position);
				
				if(squaredDistanceToTarget > states[currentStateIndex].SquaredRadius)
				{
					if(currentStateIndex != 0)
					{
						states[currentStateIndex].Exit(this);
						currentStateIndex -= 1;
						states[currentStateIndex].Enter(this);
					}
				}

				if(currentStateIndex < states.Count - 1)
				{
					if(squaredDistanceToTarget < states[currentStateIndex + 1].SquaredRadius)
					{
						states[currentStateIndex].Exit(this);
						currentStateIndex += 1;
						states[currentStateIndex].Enter(this);
					}
				}
			}

			states[currentStateIndex].Execute(this);
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