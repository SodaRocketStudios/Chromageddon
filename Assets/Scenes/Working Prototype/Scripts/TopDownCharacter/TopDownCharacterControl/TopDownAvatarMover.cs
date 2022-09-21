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

			Stat speedStat = GetComponent<CharacterData>().CharacterStats["MoveSpeed"];
			speedStat.OnValueChanged += UpdateMoveSpeed;
			UpdateMoveSpeed(speedStat.Value);
		}

		void Update()
		{
			Move(input.MoveDirection);
		}

		private void Move(Vector2 direction)
		{
			characterController.Velocity = moveSpeed*direction;
		}

		private void UpdateMoveSpeed(float value)
		{
			moveSpeed = value;
		}
	}
}