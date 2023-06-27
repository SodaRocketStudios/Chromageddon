using UnityEngine;

namespace SRS.LevelSystem
{
	public class XPPickup : MonoBehaviour
	{
		[SerializeField] private float moveSpeed;
		private int xpValue = 1;

		public Transform Target;

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

        private void OnTriggerEnter2D(Collider2D other)
		{
			CharacterLevel characterLevel;

			if(other.gameObject.TryGetComponent<CharacterLevel>(out characterLevel))
			{
				characterLevel.AddXP(xpValue);
				Destroy(gameObject);
			}
		}
	}
}