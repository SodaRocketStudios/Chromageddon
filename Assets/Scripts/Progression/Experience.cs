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

		private const int MAX_COLOR_VALUE = 100;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void Merge()
		{
			OnPickup?.Invoke(this);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			CharacterLevel level;

			if(other.TryGetComponent(out level))
			{
				level.AddXP(value);
				OnPickup?.Invoke(this);
			}
		}
	}
}