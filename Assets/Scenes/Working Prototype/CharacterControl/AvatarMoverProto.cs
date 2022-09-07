using UnityEngine;

namespace SodaRocket.CharacterControllerSystem
{
	[RequireComponent(typeof(InputInterfaceProto))]
	public class AvatarMoverProto : MonoBehaviour
	{
		private InputInterfaceProto input;
		private CharacterController2D characterController;

		private float moveSpeed = 10;

		void Start()
		{
			input = GetComponent<InputInterfaceProto>();
			characterController = GetComponent<CharacterController2D>();
		}

		void Update()
		{
			Move(input.MoveDirection);
		}

		private void Move(Vector2 direction)
		{
			characterController.Velocity = moveSpeed*direction;
			// transform.position += (Vector3)(moveSpeed*direction*Time.deltaTime);
		}
	}
}