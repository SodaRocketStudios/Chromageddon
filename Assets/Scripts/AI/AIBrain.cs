using UnityEngine;
using SRS.Input;
using System.Collections.Generic;

namespace SRS.AI
{
    public class AIBrain : MonoBehaviour, IInputSource
    {
		private State currentState;
		public State CurrentState
		{
			get => currentState;
			set
			{
				if(currentState != value)
				{
					currentState?.Exit(this);
					currentState = value;
				}
			}
		}

		private Vector2 moveInput;
        public Vector2 MoveInput
		{
			get
			{
				return moveInput.normalized;
			}

			set
			{
				moveInput = value;
			}
		}

		private Vector2 lookInput;
        public Vector2 LookInput
		{
			get
			{
				return lookInput;
			}

			set
			{
				lookInput = value;
			}
		}

		private bool attackInput = false;
        public bool AttackInput
		{
			get
			{
				return attackInput;
			}

			set
			{
				attackInput = value;
			}
		}

		private Transform player;
		public Transform Player
		{
			get
			{
				if(player == null)
				{
					FindPlayer();
				}
				return player;
			}
		}

		private Vector2 target;
		public Vector2 Target
		{
			get => target;
			set => target = value;
		}

		public float TargetDistanceSquared
		{
			get
			{
				if(target == Vector2.zero)
				{
					return (transform.position - Player.position).sqrMagnitude;
				}
				
				return (transform.position - (Vector3)target).sqrMagnitude;
			}
		}

		private List<Transition> transitions;
		public List<Transition> Transitions
		{
			set
			{
				transitions = value;
			}
		}

		private void OnEnable()
		{
			target = Vector2.zero;
		}

		private void Update()
		{
			foreach(Transition transition in transitions)
			{
				CurrentState = transition.Test(this);
			}

			currentState?.Execute(this);
		}

		private void FindPlayer()
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
    }
}