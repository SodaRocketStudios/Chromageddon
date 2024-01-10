using System;
using UnityEngine;
using UnityEngine.Events;

namespace SRS.Utils
{
	[Serializable]
	public class Fraction
	{
		public UnityEvent<float> OnCurrentChange;
		public UnityEvent<float> OnMaxChange;

		private float current;
		public float Current
		{
			get
			{
				return current;
			}

			set
			{
				current = Mathf.Max(value, 0);
				current = Mathf.Min(current, Max);
				OnCurrentChange?.Invoke(current);
			}
		}

		private float max;
		public float Max
		{
			get
			{
				return max;
			}

			set
			{
				max = Mathf.Max(value, 0);
				OnMaxChange?.Invoke(max);
			}
		}

		public Fraction()
		{
			
		}

		public Fraction(float max, float current)
		{
			Max = max;
			Current = current;
		}

		public void SetCurrentToMax()
		{
			Current = Max;
		}
	}
}
