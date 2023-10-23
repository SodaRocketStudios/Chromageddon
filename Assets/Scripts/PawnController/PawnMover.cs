using UnityEngine;
using SRS.Input;
using SRS.Stats;
using System;

namespace SRS.PawnController
{
    public class PawnMover : MonoBehaviour
    {
        private IInputSource inputSource;

        private Rigidbody2D body;

        private StatContainer CharacterStats;

        private const float FORCE_DECAY = .9f;

        private Vector2 forces;

        private void Awake()
        {
            inputSource = GetComponent<IInputSource>();
            body = GetComponent<Rigidbody2D>();
            CharacterStats = GetComponent<StatContainer>();
        }

        private void Update()
        {
            HandleRotation();
        }

        private void FixedUpdate()
        {
            HandleMovement();
            forces *= FORCE_DECAY;
        }

        public void AddForce(Vector2 force)
        {
            forces += force;
        }

        public void EnableMovement()
        {
            throw new NotImplementedException();
        }

        public void DisableMovement()
        {
            throw new NotImplementedException();
        }

        public void EnableRotation()
        {
            throw new NotImplementedException();
        }

        public void DisableRotation()
        {
            throw new NotImplementedException();
        }

        private void HandleMovement()
        {
            body.velocity = (inputSource.MoveInput*CharacterStats["Speed"].Value) + (forces*body.mass);
        }

        private void HandleRotation()
        {
            if(inputSource.LookInput.magnitude > 0)
            {
                transform.right = inputSource.LookInput;
            }
        }
    }
}
