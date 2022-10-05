using UnityEngine;
using UnityEngine.InputSystem;

namespace SRS.TopDownCharacterControl
{
	[RequireComponent(typeof(TopDownInputInterface))]
	public class TopDownInputHandler : MonoBehaviour
	{
		private TopDownInputInterface input;

		private Controls controls;
		private InputAction moveAction;
		private InputAction lookAction;
		private InputAction attackAction;

		private void Start()
		{
			input = GetComponent<TopDownInputInterface>();
		}

		private void OnEnable()
		{
			controls = new Controls();
			controls.Avatar.Enable();
			moveAction = controls.Avatar.Move;
			lookAction = controls.Avatar.Look;
			attackAction = controls.Avatar.Attack;
		}

		private void Update()
		{
			input.MoveDirection = moveAction.ReadValue<Vector2>();
			input.LookTarget = HandleLookInput(lookAction.ReadValue<Vector2>());
			input.IsAttacking = attackAction.IsPressed();
		}

		private Vector2 HandleLookInput(Vector2 pointerPosition)
		{
			return Camera.main.ScreenToWorldPoint(pointerPosition);
		}

		private void OnDisable()
		{
			controls.Avatar.Disable();
		}
	}
}