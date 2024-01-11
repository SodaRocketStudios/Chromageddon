using System;
using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.Progression
{
	public class Experience : PooledObject
	{
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
			}
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