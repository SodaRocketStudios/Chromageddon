using UnityEngine;

namespace SRS.InputV1
{
	public interface IInputProcessor
	{
		public Vector2 MoveDirection {get; set;}
		public Vector2 LookTarget {get; set;}
		public bool IsAttacking {get; set;}
	}
}