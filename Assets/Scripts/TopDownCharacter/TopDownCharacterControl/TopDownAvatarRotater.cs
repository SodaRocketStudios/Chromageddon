using UnityEngine;

namespace SRS.TopDownCharacterControl
{
	[RequireComponent(typeof(TopDownInputInterface))]
	public class TopDownAvatarRotater : MonoBehaviour
	{
		private TopDownInputInterface input;

		void Start()
		{
			input = GetComponent<TopDownInputInterface>();	
		}

		void Update()
		{
			LookAtTarget(input.LookTarget);
		}

		private void LookAtTarget(Vector2 target)
		{
			Vector2 directionVector = target - (Vector2)transform.position;

			float direction = Vector2.SignedAngle(Vector2.right, directionVector);

			transform.eulerAngles = new Vector3(0, 0, direction);
		}
	}
}