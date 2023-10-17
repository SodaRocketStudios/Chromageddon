using UnityEngine;
using SRS.Input;

namespace SRS.PawnController
{
    public class PawnInputHandler : MonoBehaviour
    {
        public Vector2 Moveinput{get => ProcessMoveInput();}

        [SerializeField] private IInputSource inputSource;

        private Vector2 ProcessMoveInput()
        {
            return inputSource.MoveInput;
        }

        private Vector2 ProcessLookInput()
        {
            if(inputSource.IsReadingLookTarget)
            {
                return inputSource.LookInput;
            }

            return (Vector2)transform.position + inputSource.LookInput;
        }
    }
}
