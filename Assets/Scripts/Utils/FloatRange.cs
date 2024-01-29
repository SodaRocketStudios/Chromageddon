using System;
using UnityEngine;

namespace SRS.Utils
{
	[Serializable]
	public class FloatRange
	{
		public Action OnMaxChange;
		public Action OnMinChange;
		public Action OnValueChange;

		protected float current;
		public float Current
		{
			get => current;
			set
			{
				current = Mathf.Clamp(value, min, max);
			}
		}

		[SerializeField] protected float min;
		public float Min
		{
			get => min;
			set => min = value;
		}

		[SerializeField] protected float max;
		public float Max
		{
			get => max;
			set => max = value;
		}
    }
}