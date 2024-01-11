using System;
using UnityEngine;
using SRS.Stats;
using SRS.Combat;
using SRS.Utils.ObjectPooling;
using SRS.Utils;
using SRS.AI;

namespace SRS.EnemyManagement
{
	public class Enemy : PooledObject
	{
		private bool ignoreRecycleRequests;
		public bool IgnoreRecycleRequests => ignoreRecycleRequests;

		public Action<Enemy> OnEnemyDeath;

		private AIBrain brain;
		private StatContainer statContainer;
		private Weapon weapon;
		private SpriteRenderer spriteRenderer;
		private Rigidbody2D rigidody;
		private new Collider2D collider;
		private HitHandler hitHandler;

		private void Awake()
		{
			brain = GetComponent<AIBrain>();
			statContainer = GetComponent<StatContainer>();
			spriteRenderer = GetComponent<SpriteRenderer>();
			rigidody = GetComponent<Rigidbody2D>();
			collider = GetComponent<Collider2D>();
			hitHandler = GetComponent<HitHandler>();
		}

		private void Start()
		{
			hitHandler.Health.OnDeath += OnDeath;
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

			weapon.Equip(statContainer);

			ignoreRecycleRequests = enemyData.IgnoreRecycleRequests;

			Elitify(enemyData, elitifications);

			hitHandler.Initialize();

			Debug.Log(hitHandler.Health.Value.Max);
			// TODO -- does the collider need to be set up for different enemy types?
			// TODO -- Set enemy weapon
			// TODO -- determine if i need rigidbody here.
        }

		private void Elitify(EnemyData enemyData, int elitifications)
		{
			while(elitifications > 0)
			{
				foreach(StatModifier modifier in enemyData.EliteModifiers)
				{
					modifier.Apply(statContainer);
				}
				elitifications--;
			}
		}

		public void OnDeath()
		{
			OnEnemyDeath?.Invoke(this);
		}
    }
}