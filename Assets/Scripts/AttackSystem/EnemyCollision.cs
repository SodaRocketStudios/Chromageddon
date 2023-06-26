using UnityEngine;
using SRS.StatSystem;

namespace SRS.AttackSystem
{
	public class EnemyCollision : MonoBehaviour
	{
		private LayerMask playerLayer;

		private CharacterStats stats;

		private void Start()
		{
			playerLayer = LayerMask.NameToLayer("Player");
			stats = GetComponent<CharacterStats>();
		}

		private void OnCollisionStay2D(Collision2D other)
		{
			if(other.gameObject.layer == playerLayer)
			{
				other.gameObject.GetComponent<HitHandler>().HandleHit(stats);
			}	
		}
	}
}