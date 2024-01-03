using UnityEngine;
using SRS.Stats;
using SRS.Combat;
using SRS.Utils.ObjectPooling;
using SRS.AI;

namespace SRS.EnemyManagement
{
	public class Enemy : PooledObject
	{
		private bool ignoreRecycleRequests;
		public bool IgnoreRecycleRequests => ignoreRecycleRequests;

		private AIBrain brain;
		private StatContainer statContainer;
		private Weapon weapon;
		private SpriteRenderer spriteRenderer;
		private Rigidbody2D rigidody;
		private new Collider2D collider;

		private void Awake()
		{
			brain = GetComponent<AIBrain>();
			statContainer = GetComponent<StatContainer>();
			spriteRenderer = GetComponent<SpriteRenderer>();
			rigidody = GetComponent<Rigidbody2D>();
			collider = GetComponent<Collider2D>();
		}

        public void Initialize(EnemyData enemyData, int elitifications)
        {
			brain.CurrentState = enemyData.InitialState;

			weapon = enemyData.Weapon;

			spriteRenderer.sprite = enemyData.Sprite;
			spriteRenderer.color = enemyData.Color;

			statContainer.ResetStats();

			foreach(StatModifier modifier in enemyData.InitialStats)
			{
				modifier.Apply(statContainer);
			}

			ignoreRecycleRequests = enemyData.IgnoreRecycleRequests;

			Elitify(enemyData, elitifications);

			//TODO -- does the collider need to be set up for different enemy types?
        }

		private void Elitify(EnemyData enemyData, int elitifications)
		{
			while(elitifications > 0)
			{
				foreach(EliteStatModifier modifier in enemyData.EliteModifiers)
				{
					modifier.Apply(statContainer);
				}
				elitifications--;
			}
		}
    }
}