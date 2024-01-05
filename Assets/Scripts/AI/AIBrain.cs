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
				return moveInput;
			}
		}

		private Vector2 lookInput;
        public Vector2 LookInput
		{
			get => lookInput;
		}

		private bool attackInput;
        public bool AttackInput
		{
			get => attackInput;
		}

		public float TargetDistanceSquared{get; private set;}

		private Transform player;

		private void OnEnable()
		{
			player = Physics2D.CircleCast(transform.position, 200, transform.right, 0, LayerMask.GetMask("Player")).transform;
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
				currentState = state;
			}
		}
    }
}