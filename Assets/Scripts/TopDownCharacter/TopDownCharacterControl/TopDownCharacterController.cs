using UnityEngine;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl
{
	public class TopDownCharacterController : MonoBehaviour
	{
		public Vector2 MoveDirection{get; set;}

		public Vector2 LookTarget{get; set;}

		private Rigidbody2D rb;

		private CharacterStats characterStats;

		private void Awake()
		{
			characterStats = GetComponent<CharacterStats>();
			rb = GetComponent<Rigidbody2D>();
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
			rb.MovePosition(rb.position + MoveDirection*characterStats["MoveSpeed"]*Time.deltaTime);
		}

		private void LookAtTarget()
		{
			Vector2 directionVector = LookTarget - (Vector2)transform.position;

			float direction = Vector2.SignedAngle(Vector2.right, directionVector);

			transform.eulerAngles = new Vector3(0, 0, direction);
		}
	}
}