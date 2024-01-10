using UnityEngine;

namespace SRS.Utils
{
	public class TargetFollower : MonoBehaviour
	{
		[SerializeField] private float maxSpeed;

		[SerializeField] private float acceleration;

		private float speed;

		[SerializeField] private Transform target;

		public void SetTarget(Transform target)
		{
			this.target = target;
		}

		private void Update()
		{
			speed += acceleration*Time.deltaTime;
			speed = Mathf.Min(speed, maxSpeed);

			MoveTowardTarget();
		}

		private void MoveTowardTarget()
		{
			if(target == null)
			{
				// find target
				return;
			}
			
			Vector2 direction;

			direction = target.position - transform.position;

			transform.Translate(direction*speed*Time.deltaTime);
		}
	}
}