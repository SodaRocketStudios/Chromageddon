using UnityEngine;
using SRS.Stats;

namespace SRS.Progression
{
	public class XPMover : MonoBehaviour
	{
		[SerializeField] private float maxSpeed;

		[SerializeField] private float acceleration;

		private float attractionRange;

		private float speed = 0;

		private Transform player;

		private bool inRange = false;

		private void OnEnable()
		{
			speed = 0;
			inRange = false;
		}

		private void Update()
		{
			MoveTowardTarget();
		}

		private void MoveTowardTarget()
		{
			if(player == null)
			{
				FindPlayer();
				speed = 0;
				return;
			}

			if(!inRange)
			{
				CheckRange();
				return;
			}

			Vector2 direction;

			direction = (player.position - transform.position).normalized;

			transform.Translate(direction*speed*Time.deltaTime);

			speed += acceleration*Time.deltaTime;
			speed = Mathf.Min(speed, maxSpeed);
		}

		private void FindPlayer()
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
			attractionRange = player.GetComponent<StatContainer>()["Pickup Range"].Value;
		}

		private void CheckRange()
        {
            inRange = Vector2.Distance(player.position, transform.position) <= attractionRange;
        }
	}
}