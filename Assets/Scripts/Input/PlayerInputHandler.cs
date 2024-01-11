using UnityEngine;
using UnityEngine.InputSystem;

namespace SRS.Input
{
    public class PlayerInputHandler : MonoBehaviour, IInputSource
    {
        private Vector2 moveInput;
        public Vector2 MoveInput
        {
            get
            {
                if(MovementEnabled)
                {
                    return moveInput;
                }
                
                return Vector2.zero;
            }
        }

        private Vector2 lookInput;
        public Vector2 LookInput
        {
            get
            {
                if(LookEnabled)
                {
                    return lookInput;
                }
                
                return Vector2.zero;
            }
        }

        private bool attackInput;
        public bool AttackInput
        {
            get
            {
                if(AttackEnabled)
                {
                    return attackInput;
                }

                return false;
            }
        }

        public bool MovementEnabled{get; set;}

        public bool LookEnabled{get; set;}

        public bool AttackEnabled{get; set;}

        private bool IsUsingMouse;

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        public void SetControlsActive(bool isActive)
        {
            MovementEnabled = isActive;
            LookEnabled = isActive;
            AttackEnabled = isActive;
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
