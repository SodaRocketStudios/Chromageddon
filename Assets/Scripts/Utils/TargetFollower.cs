using UnityEngine;

namespace SRS.Utils
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