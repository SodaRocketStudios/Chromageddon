using UnityEngine;

namespace SodaRocket.CharacterControllerSystem
{
	public class InputInterfaceProto : MonoBehaviour
	{
		private Vector2 moveDirection;
		public Vector2 MoveDirection
		{
			get
			{
				return moveDirection;
			}
			set
			{
				moveDirection = value;
			}
		}

		private Vector2 lookTarget;
		public Vector2 LookTarget
		{
			get
			{
				return lookTarget;
			}
			set
			{
				lookTarget = value;
			}
		}

		private bool isAttacking;
		public bool IsAttacking
		{
			get
			{
				return isAttacking;
			}
			set
			{
				isAttacking = value;
			}
		}
	}
}