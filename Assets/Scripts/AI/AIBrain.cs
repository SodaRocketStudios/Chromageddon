using UnityEngine;
using SRS.Input;

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
				ChangeState(value);
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

		public float TargetDistanceSquared{get; private set;}

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

		private void OnEnable()
		{
			FindPlayer();
		}

		private void Update()
		{
			currentState.Execute(this);
		}

		private void FixedUpdate()
		{
			TargetDistanceSquared = (transform.position - player.position).sqrMagnitude;
		}

		public void ChangeState(State state)
		{
			if(currentState != state)
			{
				state.Exit(this);
				currentState = state;
			}
		}

		private void FindPlayer()
		{
			player = Physics2D.CircleCast(transform.position, 200, transform.right, 0, LayerMask.GetMask("Player")).transform;
		}
    }
}