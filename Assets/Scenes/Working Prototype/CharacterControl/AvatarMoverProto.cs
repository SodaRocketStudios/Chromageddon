using UnityEngine;

namespace SodaRocket.CharacterController
{
	[RequireComponent(typeof(InputInterfaceProto))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class AvatarMoverProto : MonoBehaviour
	{
		private Rigidbody2D rigidbody2;
		private InputInterfaceProto input;

		private float moveSpeed = 10;

		void Start()
		{
			rigidbody2 = GetComponent<Rigidbody2D>();
			input = GetComponent<InputInterfaceProto>();
		}

		void Update()
		{
			Move(input.MoveDirection);
		}

		private void Move(Vector2 direction)
		{
			rigidbody2.velocity = moveSpeed*direction;
		}
	}
}