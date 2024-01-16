using UnityEngine;
using SRS.Stats;
using System;

namespace SRS.Progression
{
	public class XPFollow : MonoBehaviour
	{
		[SerializeField] private float maxSpeed;

		[SerializeField] private float acceleration;

		private float speed = 0;

		private Transform player;

		private Vector3 target;

		private float attractionRange;

		private bool inRange = false;

		private bool isMerging = false;

		private void OnEnable()
		{
			speed = 0;
			inRange = false;
			isMerging = false;
		}

		private void Update()
		{
			if(player == null)
			{
				FindPlayer();
				speed = 0;
				return;
			}

			if(isMerging)
			{
				speed = maxSpeed;
				MoveTowardTarget();
			}

			if(!inRange)
			{
				CheckRange();
				speed = 0;
				return;
			}

			target = player.transform.position;

			MoveTowardTarget();
		}

		public void StartMerge(Vector3 targetLocation)
		{
			isMerging = true;
			target = targetLocation;
		}

        private void MoveTowardTarget()
		{
			Vector2 direction;

			direction = (target - transform.position).normalized;

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