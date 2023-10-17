using UnityEngine;

namespace SRS.Input
{
    public interface IInputSource
    {
        public Vector2 MoveInput{get;}
        public Vector2 LookInput{get;}
        public bool AttackInput{get;}

        public bool IsReadingLookTarget{get;}
    }
}