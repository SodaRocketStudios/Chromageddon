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

		private int xpValue = 1;
		public int XPValue
		{
			get => xpValue;
		}

		public Color Color
		{
			get => spriteRenderer.color;
		}

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

        public void Initialize(EnemyData data, int elitifications)
        {
			brain.Transitions = data.stateTransitions;

			weapon = data.Weapon;

			spriteRenderer.sprite = data.Sprite;
			spriteRenderer.color = data.Color;

			transform.localScale = data.Scale;

			xpValue = data.xpValue;

			statContainer.ResetStats();

			foreach(StatModifier modifier in data.InitialStats)
			{
				modifier.Apply(statContainer);
			}

			GetComponent<AttackManager>().Weapon = weapon;

			ignoreRecycleRequests = data.IgnoreRecycleRequests;
			elitifications = 1;

			Elitify(data, elitifications);

			hitHandler.Initialize();
        }

		private void Elitify(EnemyData enemyData, int elitifications)
		{
			GetComponentInChildren<EliteIndicator>().Draw(elitifications);

			while(elitifications > 0)
			{
				foreach(StatModifier modifier in enemyData.EliteModifiers)
				{
					modifier.Apply(statContainer);
				}

				xpValue *= 2;

				elitifications--;
			}
		}

		public void OnDeath()
		{
			OnEnemyDeath?.Invoke(this);
		}
    }
}