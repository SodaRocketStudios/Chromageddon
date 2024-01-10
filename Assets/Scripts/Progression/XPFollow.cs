using UnityEngine;

namespace SRS.Progression
{
	public class XPFollow : MonoBehaviour
	{
		[SerializeField] private float maxSpeed;

		[SerializeField] private float acceleration;

		private float speed;

		private Transform target;

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
				speed = 0;
				return;
			}

			Vector2 direction;

			direction = (target.position - transform.position).normalized;

			transform.Translate(direction*speed*Time.deltaTime);
		}
	}
}