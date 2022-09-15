using UnityEngine;

namespace SRS.TopDownCharacterController
{
	[RequireComponent(typeof(TopDownInputInterface))]
	public class TopDownAvatarMover : MonoBehaviour
	{
		private TopDownInputInterface input;
		private TopDownCharacterController characterController;

		private float moveSpeed = 5;

		void Start()
		{
			input = GetComponent<TopDownInputInterface>();
			characterController = GetComponent<TopDownCharacterController>();
		}

		void Update()
		{
			Move(input.MoveDirection);
		}

		private void Move(Vector2 direction)
		{
			characterController.Velocity = moveSpeed*direction;
		}
	}
}