using UnityEngine;
using UnityEngine.InputSystem;

namespace SRS.Input
{
    public class PlayerInput : MonoBehaviour, IInputSource
    {
        public Vector2 MoveInput => HandleMoveinput();
        public Vector2 LookInput  => HandleLookInput();
        public bool AttackInput => HandleAttackInput();
        public bool IsReadingLookTarget => activeControlScheme == inputActions.KBMScheme;

        private Controls inputActions;

        private InputControlScheme? activeControlScheme;

        private void Awake()
        {
            inputActions = new Controls();
        }

        private void OnEnable()
        {
            inputActions.Avatar.Enable();

            InputSystem.onDeviceChange += HandleDeviceChange;
        }


        private void OnDisable()
        {
            inputActions.Avatar.Disable();

            InputSystem.onDeviceChange -= HandleDeviceChange;
        }

        private Vector2 HandleMoveinput()
        {
            return inputActions.Avatar.Move.ReadValue<Vector2>();
        }

        private Vector2 HandleLookInput()
        {
            return inputActions.Avatar.Look.ReadValue<Vector2>();
        }

        private bool HandleAttackInput()
        {
            return inputActions.Avatar.Attack.IsPressed();
        }

        private void HandleDeviceChange(InputDevice device, InputDeviceChange change)
        {
            Debug.Log(device);
            activeControlScheme = InputControlScheme.FindControlSchemeForDevice(device, inputActions.controlSchemes);
        }
    }
}
