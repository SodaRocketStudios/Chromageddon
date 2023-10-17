using UnityEngine;
using SRS.StatSystem;
using SRS.InputV1;

namespace SRS.TopDownCharacterControl
{
	public class TopDownCharacterController : MonoBehaviour
	{
		private IInputProcessor inputProcessor;

		private Rigidbody2D body;

		private CharacterStats characterStats;

		private void Awake()
		{
			characterStats = GetComponent<CharacterStats>();
			body = GetComponent<Rigidbody2D>();

			inputProcessor = GetComponent<IInputProcessor>();
		}

		private void Update()
		{
			LookAtTarget();
		}

		private void FixedUpdate()
		{
			Move();
		}

		private void Move()
		{
			Vector2 newPosition = body.position + inputProcessor.MoveDirection.normalized*characterStats["Speed"]*Time.fixedDeltaTime;

			body.MovePosition(newPosition);
		}

        private void LookAtTarget()
		{
			if(inputProcessor.LookTarget == null)
			{
				return;
			}

			Vector2 directionVector = inputProcessor.LookTarget - (Vector2)transform.position;

			float direction = Vector2.SignedAngle(Vector2.right, directionVector);

			transform.eulerAngles = new Vector3(0, 0, direction);
		}
	}
}