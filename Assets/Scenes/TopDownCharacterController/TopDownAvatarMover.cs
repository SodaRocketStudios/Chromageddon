using UnityEngine;

namespace SodaRocket.TopDownCharacterController
{
	[RequireComponent(typeof(TopDownInputInterface))]
	public class TopDownAvatarMover : MonoBehaviour
	{
		private TopDownInputInterface input;
		private CharacterController2D characterController;

		private float moveSpeed = 5;

		void Start()
		{
			input = GetComponent<TopDownInputInterface>();
			characterController = GetComponent<CharacterController2D>();
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