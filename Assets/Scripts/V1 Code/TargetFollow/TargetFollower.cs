using UnityEngine;

namespace SRS.TargetFollow
{
	public class TargetFollower : MonoBehaviour
	{
		[SerializeField] private Transform target;

		private void Update()
		{
			// TODO -- allow for smooth follow with damper and/or acceleration.
			transform.position = target.position;
		}
	}
}