using System;
using UnityEngine;

namespace SRS.LevelSystem
{
	public class XPPickup : MonoBehaviour
	{
		[SerializeField] private float moveSpeed;
		private float xpValue;

		public Transform Target;

		private void Update()
		{
			if(Target != null)
			{
				// move toward target;
				MoveToward(Target.position);
			}
		}

        private void MoveToward(Vector3 target)
        {
			transform.Translate((target - transform.position)*moveSpeed*Time.deltaTime, Space.World);
        }

        private void OnCollisionEnter2D(Collision2D other)
		{
			// if collide with player add xp
		}
	}
}