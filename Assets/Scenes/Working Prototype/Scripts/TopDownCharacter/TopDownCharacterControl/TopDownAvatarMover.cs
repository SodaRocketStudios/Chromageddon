using UnityEngine;
using SRS.Stats;

namespace SRS.TopDownCharacterController
{
	[RequireComponent(typeof(TopDownInputInterface))]
	public class TopDownAvatarMover : MonoBehaviour
	{
		private TopDownInputInterface input;
		private TopDownCharacterController characterController;

		private float moveSpeed;

		void Start()
		{
			input = GetComponent<TopDownInputInterface>();
			characterController = GetComponent<TopDownCharacterController>();
			// moveSpeed = GetComponent<CharacterData>().CharacterStats["MoveSpeed"].Value;
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