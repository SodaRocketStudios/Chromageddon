using UnityEngine;

namespace SRS.TopDownCharacterControl
{
	public class TopDownInputInterface : MonoBehaviour
	{
		public Vector2 MoveDirection{get; set;}

		public Vector2 LookTarget{get; set;}

		public bool IsAttacking{get; set;}

		public bool IsUsingAbility{get; set;}
	}
}