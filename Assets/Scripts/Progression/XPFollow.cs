using UnityEngine;
using SRS.Stats;

namespace SRS.Progression
{
	public class XPFollow : MonoBehaviour
	{
		[SerializeField] private float maxSpeed;

		[SerializeField] private float acceleration;

		private float speed;

		private Transform player;

		private float attractionRange;

		private bool inRange = false;

		private void OnEnable()
		{
			speed = 0;
			inRange = false;
		}

		private void Update()
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
				speed = 0;
				return;
			}

			speed += acceleration*Time.deltaTime;
			speed = Mathf.Min(speed, maxSpeed);

			MoveTowardTarget();
		}

		private void MoveTowardTarget()
		{
			Vector2 direction;

			direction = (player.position - transform.position).normalized;

			transform.Translate(direction*speed*Time.deltaTime);
		}

        private void CheckRange()
        {
            inRange = Vector2.Distance(player.position, transform.position) <= attractionRange;
        }

        private void FindPlayer()
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
			attractionRange = player.GetComponent<StatContainer>()["Attraction Range"].Value;
		}
	}
}