using System.Collections.Generic;
using UnityEngine;
using SRS.Extensions.Vector;
using SRS.InputV1;

namespace SRS.TopDownCharacterControl.AI
{
	public class AIBrain : MonoBehaviour, IInputProcessor
	{
		[SerializeField] private List<State> states = new List<State>();

		private Transform target;
		public Transform Target => target;

        public Vector2 MoveDirection {get; set;}
        public Vector2 LookTarget {get; set;}
        public bool IsAttacking {get; set;}

        private int currentStateIndex = 0;

		private void Awake()
        {
            for (int i = 0; i < states.Count; i++)
            {
                states[i] = Object.Instantiate(states[i]);
            }

            states[0].Enter(this);

            FindPlayer();
        }

        private void Update()
		{
			if(states[currentStateIndex] == null) return;

			if(target == null) return;

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

			states[currentStateIndex].Execute(this);
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}

		public void ClearTarget()
		{
			target = null;
			MoveDirection = Vector2.zero;
			IsAttacking = false;
		}

		public void MoveToward(Vector2 position)
		{
			MoveDirection = position - (Vector2)transform.position;
		}

		public void LookAt(Vector2 position)
		{
			LookTarget = position;
		}

		public void StopMoving()
		{
			MoveDirection = Vector2.zero;
		}

        private void FindPlayer()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 100, LayerMask.GetMask("Player"));

            if (hits.Length > 0)
            {
                target = hits[0].transform;
            }
        }
	}
}