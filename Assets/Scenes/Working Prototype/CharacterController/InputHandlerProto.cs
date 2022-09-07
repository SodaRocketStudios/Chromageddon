using UnityEngine;
using UnityEngine.InputSystem;

namespace SodaRocket.CharacterControllerSystemProto
{
	[RequireComponent(typeof(InputInterfaceProto))]
	public class InputHandlerProto : MonoBehaviour
	{
		private InputInterfaceProto input;

		private Controls controls;
		private InputAction moveAction;
		private InputAction lookAction;
		private InputAction attackAction;

		private void Start()
		{
			input = GetComponent<InputInterfaceProto>();
		}

		private void OnEnable()
		{
			controls = new Controls();
			controls.AvatarControls.Enable();
			moveAction = controls.AvatarControls.Move;
			lookAction = controls.AvatarControls.Look;
			attackAction = controls.AvatarControls.Attack;
		}

		private void Update()
		{
			input.MoveDirection = moveAction.ReadValue<Vector2>();
			input.LookTarget = HandleLookInput(lookAction.ReadValue<Vector2>());
			input.IsAttacking = attackAction.IsPressed();
		}

		private Vector2 HandleLookInput(Vector2 pointerPosition)
		{
			// Controller and mouse input need to be handled differently.
			return Camera.main.ScreenToWorldPoint(pointerPosition);
		}

		private void OnDisable()
		{
			controls.AvatarControls.Disable();
		}
	}
}