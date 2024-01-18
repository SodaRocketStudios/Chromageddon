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
			set => velocity = value;
		}

		private void OnEnable()
		{
			velocity = Vector2.zero;
		}

        public void MoveTowardTarget(Vector3 target)
		{
			transform.Translate(velocity*Time.deltaTime);
			
			Vector2 direction = (target - transform.position).normalized;

			velocity += direction*acceleration;
			velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
		}
	}
}