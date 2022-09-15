using UnityEngine;

namespace SRS.CharacterControllerSystemProto
{
	[RequireComponent(typeof(InputInterfaceProto))]
	public class AvatarMoverProto : MonoBehaviour
	{
		private InputInterfaceProto input;
		private CharacterController2DProto characterController;

		private float moveSpeed = 5;

		void Start()
		{
			input = GetComponent<InputInterfaceProto>();
			characterController = GetComponent<CharacterController2DProto>();
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