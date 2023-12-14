using UnityEngine;
using SRS.Stats;
using SRS.Combat;
using SRS.Utils.ObjectPooling;

namespace SRS.EnemyManagement
{
	public class Enemy : MonoBehaviour, IPoolable
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

        public void OnGet()
        {
            // Set data on components.
			// sprite
			// color?
			// stats
			// weapon
			// state machine
			// collider?
        }

        public void OnReturn()
        {
            statContainer.ResetStats();
        }
    }
}