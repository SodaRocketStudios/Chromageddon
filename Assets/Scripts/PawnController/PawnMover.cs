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

        private void CollisionCheck()
        {
            float distance = body.velocity.magnitude*Time.fixedDeltaTime;

            TestVerticalCollisions(distance);
            TestHorizontalCollisions(distance);
        }

        private void TestVerticalCollisions(float distance)
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.up*collider.radius*Mathf.Sign(body.velocity.y), Vector2.up, distance*Time.fixedDeltaTime, collisionLayers);

            Debug.DrawRay((Vector2)transform.position + Vector2.up*collider.radius*Mathf.Sign(body.velocity.y), Vector2.up*distance, Color.green);

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

            Debug.DrawRay((Vector2)transform.position + Vector2.right*collider.radius*Mathf.Sign(body.velocity.x), Vector2.right*distance, Color.red);

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
