using UnityEngine;

namespace SRS.TargetFollow
{
	public class TargetFollower : MonoBehaviour
	{
		[SerializeField] private Transform target;

		private void Update()
		{
			transform.position = target.position;
		}
	}
}