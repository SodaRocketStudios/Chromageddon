using UnityEngine;

namespace SRS.Progression
{
	public class ExperienceMover : MonoBehaviour
	{
		[SerializeField] private float maxSpeed;

		[SerializeField] private float acceleration;

		private Vector2 velocity;
		public Vector2 Veloctiy
		{
			get => velocity;
		}

		private float speed = 0;
		public float Speed
		{
			get => speed;
			set => speed = value;
		}

		private void OnEnable()
		{
			velocity = Vector2.zero;
			speed = 0;
		}

        public void MoveTowardTarget(Transform target)
		{
			transform.Translate(velocity*Time.deltaTime);

			Vector2 direction = (target.position - transform.position).normalized;

			speed += acceleration*Time.deltaTime;
			speed = Mathf.Min(maxSpeed, speed);

			velocity = direction*speed;
		}
	}
}