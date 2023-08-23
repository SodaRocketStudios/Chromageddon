using UnityEngine;
using UnityEngine.Pool;

namespace SRS.LevelSystem
{
	public class XPPickup : MonoBehaviour
	{
		[SerializeField] private float moveSpeed;
		private int xpValue = 1;

		public Transform Target;

		private ObjectPool<GameObject> pool;

		private void Start()
		{
			TrackPickup();
			pool = GetComponentInParent<XPDropper>().pool;
		}

        private void Update()
		{
			if(Target != null)
			{
				MoveToward(Target.position);
			}
		}

        private void MoveToward(Vector3 target)
        {
			transform.Translate((target - transform.position).normalized*moveSpeed*Time.deltaTime, Space.World);
        }

		private void TrackPickup()
		{
			Physics2D.OverlapCircle(transform.position, 100, LayerMask.GetMask("Player")).GetComponent<XPAttractor>().TrackPickup(this);
		}

        private void OnTriggerEnter2D(Collider2D other)
		{
			if(Target == null) return;

			CharacterLevel characterLevel;

			if(other.gameObject.TryGetComponent<CharacterLevel>(out characterLevel))
			{
				characterLevel.AddXP(xpValue);
				other.GetComponent<XPAttractor>().StopTracking(this);
				pool.Release(gameObject);
			}
		}
	}
}