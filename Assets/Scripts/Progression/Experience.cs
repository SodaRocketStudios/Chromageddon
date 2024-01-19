using System;
using UnityEngine;
using SRS.Utils.ObjectPooling;
using SRS.Stats;

namespace SRS.Progression
{
	public class Experience : PooledObject
	{
		[SerializeField] private Gradient valueGradient;

		public Action<Experience> OnPickup;

		private int value = 0;
		public int Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
				spriteRenderer.color = valueGradient.Evaluate(Mathf.Min((float)value/MAX_COLOR_VALUE, 1));
			}
		}

		private SpriteRenderer spriteRenderer;

		private ExperienceMover mover;

		private Transform target;

		private const int MAX_COLOR_VALUE = 100;

		private Experience mergeTarget;

		private bool isInRange;

		private GameObject player = null;
		private StatContainer playerStats;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			mover = GetComponent<ExperienceMover>();
		}

		private void Start()
		{
			FindPlayer();
		}

		private void OnEnable()
		{
			target = null;
			mergeTarget = null;

			isInRange = false;

			if(player == null)
			{
				FindPlayer();
			}
		}

		private void Update()
		{
			if(target == null)
			{
				return;
			}

			mover.MoveTowardTarget(target);
		}

		private void FixedUpdate()
		{
			if(mergeTarget != null)
			{
				if(Vector2.Distance(transform.position, mergeTarget.transform.position) < 1)
				{
					mergeTarget.Value += value;
					OnPickup?.Invoke(this);
				}
			}
			else if(isInRange)
			{
				target = player.transform;
			}
			else
			{
				RangeCheck();
			}

			CollisionCheck();
		}

		public void StartMerge(Experience mergeTarget)
		{
			if(mergeTarget == this)
			{
				return;
			}

			target = mergeTarget.transform;
            this.mergeTarget = mergeTarget;
		}

        private void CollisionCheck()
        {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, mover.Veloctiy, mover.Speed*Time.fixedDeltaTime, LayerMask.GetMask("Player"));

			if(hit)
			{
				OnPickup?.Invoke(this);
				hit.transform.GetComponent<CharacterLevel>().AddXP(value);
			}
        }

		private void RangeCheck()
		{
			if(Vector2.Distance(transform.position, player.transform.position) <= playerStats["Pickup Range"].Value)
			{
				isInRange = true;
			}
		}

		private void FindPlayer()
		{
			player = GameObject.FindGameObjectWithTag("Player");
			playerStats = player.GetComponent<StatContainer>();
		}
    }
}