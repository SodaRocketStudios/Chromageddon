using UnityEngine;

namespace SRS.Utils
{
	public class TargetFollower : MonoBehaviour
	{
		[SerializeField] private Transform target;

		[SerializeField] private Vector3 offset;

		public Transform Target
		{
			get => target;
			set => target = value;
		}

		private void Update()
		{
			transform.position = target.position + offset;
		}
	}
}