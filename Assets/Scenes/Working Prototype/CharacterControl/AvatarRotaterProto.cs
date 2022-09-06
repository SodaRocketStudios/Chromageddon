using UnityEngine;

namespace SodaRocket.CharacterController
{
	[RequireComponent(typeof(InputInterfaceProto))]
	public class AvatarRotaterProto : MonoBehaviour
	{
		private InputInterfaceProto input;

		void Start()
		{
			input = GetComponent<InputInterfaceProto>();	
		}

		void Update()
		{
			LookAtTarget(input.LookTarget);
		}

		private void LookAtTarget(Vector2 target)
		{
			
		}
	}
}