using UnityEngine;
using SRS.Input;

namespace SRS.TopDownCharacterControl
{
	public class InputHandler : MonoBehaviour, IInputProcessor
	{
		public Vector2 MoveDirection {get; set;}
		public Vector2 LookTarget {get; set;}

		public bool IsAttacking {get; set;}	
	}
}