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
				currentState.Exit(this);
				currentState = value;
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

		private bool attackInput;
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

		public float TargetDistanceSquared{get; private set;}

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
			FindPlayer();
		}

		private void Update()
		{
			currentState.Execute(this);

			foreach(Transition transition in transitions)
			{
				CurrentState = transition.Test(this);
			}
		}

		private void FixedUpdate()
		{
			TargetDistanceSquared = (transform.position - player.position).sqrMagnitude;
		}

		private void FindPlayer()
		{
			player = Physics2D.CircleCast(transform.position, 200, transform.right, 0, LayerMask.GetMask("Player")).transform;
		}
    }
}