using UnityEngine;
using UnityEngine.InputSystem;
using SRS.TopDownCharacterControl.AttackSystem;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class TopDownInputHandler : MonoBehaviour
	{
		private TopDownCharacterController characterController;
		private AttackManager attackManager;
		private CharacterStats characterStats;

		private Controls controls;
		private InputAction moveAction;
		private InputAction lookAction;
		private InputAction attackAction;

		private void Start()
		{
			characterController = GetComponent<TopDownCharacterController>();
			attackManager = GetComponent<AttackManager>();
			characterStats = GetComponent<CharacterStats>();
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
			characterController.Velocity = moveAction.ReadValue<Vector2>()*characterStats.Character["MoveSpeed"].Value;
			characterController.LookTarget = HandleLookInput(lookAction.ReadValue<Vector2>());
			attackManager.IsAttacking = attackAction.IsPressed();
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