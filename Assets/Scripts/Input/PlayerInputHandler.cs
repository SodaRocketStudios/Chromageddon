using UnityEngine;
using UnityEngine.InputSystem;

namespace SRS.Input
{
    public class PlayerInputHandler : MonoBehaviour, IInputSource
    {
        private Vector2 moveInput;
        public Vector2 MoveInput => moveInput;

        private Vector2 lookInput;
        public Vector2 LookInput  => lookInput;

        private bool attackInput;
        public bool AttackInput => attackInput;

        private bool IsUsingMouse;

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        public void OnSchemeChange(PlayerInput input)
        {
            IsUsingMouse = string.Equals(input.currentControlScheme, "KBM");
        }

        public void HandleMoveinput(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        public void HandleLookInput(InputAction.CallbackContext context)
        {
            if(IsUsingMouse)
            {
                lookInput = (mainCamera.ScreenToWorldPoint(context.ReadValue<Vector2>()) - transform.position).normalized;
                return;
            }

            lookInput = context.ReadValue<Vector2>();
        }

        public void HandleAttackInput(InputAction.CallbackContext context)
        {
            attackInput = context.ReadValueAsButton();
        }
    }
}
