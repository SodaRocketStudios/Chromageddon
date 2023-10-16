using UnityEngine;

namespace SRS.Input
{
	public interface IInputProcessor
	{
		public Vector2 MoveDirection {get; set;}
		public Vector2 LookTarget {get; set;}
		public bool IsAttacking {get; set;}
	}
}