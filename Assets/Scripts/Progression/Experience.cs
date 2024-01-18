using System;
using UnityEngine;
using SRS.Utils.ObjectPooling;

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

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			mover = GetComponent<ExperienceMover>();
		}

		private void OnEnable()
		{
			target = null;
			mergeTarget = null;
		}

		private void Update()
		{
			if(target == null)
			{
				return;
			}

			mover.MoveTowardTarget(target);
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

			CollisionCheck();
		}

        private void CollisionCheck()
        {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, mover.Veloctiy, mover.Speed*Time.fixedDeltaTime, LayerMask.GetMask("Player"));

			if(hit)
			{
				hit.transform.GetComponent<CharacterLevel>().AddXP(value);
				OnPickup?.Invoke(this);
			}
        }
    }
}