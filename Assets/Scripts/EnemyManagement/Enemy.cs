using UnityEngine;
using SRS.Stats;
using SRS.Combat;

namespace SRS.EnemyManagement
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private EnemyData enemyData;

		private StatContainer statContainer;
		private Weapon weapon;
		private SpriteRenderer spriteRenderer;
		private Rigidbody2D rigidody;
		private new Collider2D collider;

		private void Awake()
		{
			statContainer = GetComponent<StatContainer>();
			weapon = GetComponent<Weapon>();
			spriteRenderer = GetComponent<SpriteRenderer>();
			rigidody = GetComponent<Rigidbody2D>();
			collider = GetComponent<Collider2D>();
		}

		public void Spawn()
		{
			// Get data and set it from enemy data
		}

		public void Despawn()
		{
			statContainer.ResetStats();
		}
	}
}