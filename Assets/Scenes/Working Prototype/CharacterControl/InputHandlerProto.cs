using UnityEngine;
using UnityEngine.InputSystem;

namespace SodaRocket.CharacterControllerSystem
{
	[RequireComponent(typeof(InputInterfaceProto))]
	public class InputHandlerProto : MonoBehaviour
	{
		private InputInterfaceProto inputInterface;

		private Controls controls;
		private InputAction moveAction;
		private InputAction lookAction;
		private InputAction attackAction;

		private void Start()
		{
			inputInterface = GetComponent<InputInterfaceProto>();
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
			inputInterface.MoveDirection = moveAction.ReadValue<Vector2>();
			inputInterface.LookTarget = HandleLookInput(lookAction.ReadValue<Vector2>());
			inputInterface.IsAttacking = attackAction.IsPressed();
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