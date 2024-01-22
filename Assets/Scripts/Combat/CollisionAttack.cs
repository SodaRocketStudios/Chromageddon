using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
	public class CollisionAttack : MonoBehaviour
	{
		private StatContainer statContainer;

		private void Awake()
		{
			statContainer = GetComponent<StatContainer>();
		}

		private void OnCollisionStay2D(Collision2D other)
		{
			if(other.collider.CompareTag("Player"))
			{
				// TODO -- get real damage type. Maybe create a ram weapon.
				other.gameObject.GetComponent<HitHandler>().Hit(statContainer, DamageType.Physical);
			}
		}
	}
}