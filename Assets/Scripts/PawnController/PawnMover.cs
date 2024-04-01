using UnityEngine;
using SRS.Input;
using SRS.Stats;
using System;

namespace SRS.PawnController
{
    public class PawnMover : MonoBehaviour
    {
        [SerializeField] private LayerMask collisionLayers;

        private IInputSource inputSource;

        private Rigidbody2D body;

        private new CircleCollider2D collider;

        private StatContainer CharacterStats;

        private const float FORCE_DECAY = .9f;

        private Vector2 forces;

        private void Awake()
        {
            inputSource = GetComponent<IInputSource>();
            body = GetComponent<Rigidbody2D>();
            CharacterStats = GetComponent<StatContainer>();
            collider = GetComponent<CircleCollider2D>();
        }

        private void OnEnable()
        {
            forces = Vector2.zero;
        }

        private void Update()
        {
            HandleRotation();
        }

        private void FixedUpdate()
        {
            HandleMovement();
            CollisionCheck();
            forces *= FORCE_DECAY;
        }

        public void AddForce(Vector2 force)
        {
            forces += force/CharacterStats["Mass"].Value;
        }

        public void AddVelocity(Vector2 velocity)
        {
            forces += velocity;
        }

        public void EnableMovement()
        {
            // TODO -- enable movement
            throw new NotImplementedException();
        }

        public void DisableMovement()
        {
            // TODO -- disable movement
            throw new NotImplementedException();
        }

        public void EnableRotation()
        {
            // TODO -- enable rotation
            throw new NotImplementedException();
        }

        public void DisableRotation()
        {
            // TODO -- disable rotation
            throw new NotImplementedException();
        }

        private void HandleMovement()
        {
            body.velocity = (inputSource.MoveInput*CharacterStats["Speed"].Value) + forces;
        }

        private void HandleRotation()
        {
            if(inputSource.LookInput.magnitude > 0)
            {
                transform.eulerAngles = Vector3.forward*Vector2.SignedAngle(Vector2.right, inputSource.LookInput);
                // transform.right = inputSource.LookInput;
            }
        }

        private void CollisionCheck()
        {
            float distance = body.velocity.magnitude*Time.fixedDeltaTime;

            TestVerticalCollisions(distance);
            TestHorizontalCollisions(distance);
        }

        private void TestVerticalCollisions(float distance)
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.up*collider.radius*Mathf.Sign(body.velocity.y), Vector2.up, distance*Time.fixedDeltaTime, collisionLayers);

            if(hit)
            {
                if(hit.transform == transform)
                {
                    return;
                }

                Vector2 velocity = body.velocity;
                velocity.y = 0;
                body.velocity = velocity;
            }
        }

        private void TestHorizontalCollisions(float distance)
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.right*collider.radius*Mathf.Sign(body.velocity.x), Vector2.right, distance*Time.fixedDeltaTime, collisionLayers);

            if(hit)
            {
                if(hit.transform == transform)
                {
                    return;
                }

                Vector2 velocity = body.velocity;
                velocity.x = 0;
                body.velocity = velocity;
            }
        }
    }
}