using UnityEngine;
using UnityEngine.InputSystem;

namespace SRS.InputV1
{
	public class InputReader : MonoBehaviour
	{
		private IInputProcessor inputProcessor;

		private Controls controls;
		private InputAction moveAction;
		private InputAction lookAction;
		private InputAction attackAction;

		private void Start()
		{
			inputProcessor = GetComponent<IInputProcessor>();
		}

		private void OnEnable()
		{
			controls = new Controls();
			controls.Avatar.Enable();
			moveAction = controls.Avatar.Move;
			lookAction = controls.Avatar.Look;
			attackAction = controls.Avatar.Attack;
		}

		private void OnDisable()
		{
			controls.Avatar.Disable();
		}

		private void Update()
		{
			inputProcessor.MoveDirection = moveAction.ReadValue<Vector2>();
			inputProcessor.LookTarget = HandleLookInput(lookAction.ReadValue<Vector2>());
			inputProcessor.IsAttacking = attackAction.IsPressed();
		}

		private Vector2 HandleLookInput(Vector2 lookTarget)
		{
			return Camera.main.ScreenToWorldPoint(lookTarget);
		}	
	}
}