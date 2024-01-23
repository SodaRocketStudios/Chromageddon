using System;
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

		public Action<Enemy> OnEnemyDeath;

		private AIBrain brain;
		private StatContainer statContainer;
		private Weapon weapon;
		private SpriteRenderer spriteRenderer;
		private HitHandler hitHandler;

		private void Awake()
		{
			brain = GetComponent<AIBrain>();
			statContainer = GetComponent<StatContainer>();
			spriteRenderer = GetComponent<SpriteRenderer>();
			hitHandler = GetComponent<HitHandler>();
		}

		private void Start()
		{
			hitHandler.Health.OnDeath += OnDeath;
		}

        public void Initialize(EnemyData enemyData, int elitifications)
        {
			brain.Transitions = enemyData.stateTransitions;

			weapon = enemyData.Weapon;

			spriteRenderer.sprite = enemyData.Sprite;
			spriteRenderer.color = enemyData.Color;

			statContainer.ResetStats();


			foreach(StatModifier modifier in enemyData.InitialStats)
			{
				modifier.Apply(statContainer);
			}

			GetComponent<AttackManager>().Weapon = weapon;

			ignoreRecycleRequests = enemyData.IgnoreRecycleRequests;

			Elitify(enemyData, elitifications);

			hitHandler.Initialize();
			
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