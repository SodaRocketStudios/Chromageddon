using System;
using UnityEngine;

namespace SRS.Utils
{
	[Serializable]
	public class FloatRange : IEquatable<FloatRange>
	{
		public Action OnMaxChange;
		public Action OnMinChange;
		public Action OnValueChange;

		[SerializeField] protected float current;
		public float Current
		{
			get => current;
			set
			{
				value = value <= min?min:value;
				current = value >= max?max:value;
			}
		}

		[SerializeField] protected float max;
		public float Max
		{
			get => max;
			set => max = value;
		}

		[SerializeField] protected float min;
		public float Min
		{
			get => min;
			set => min = value;
		}

        public bool Equals(FloatRange other)
        {
            return other.Current == current?true:false;
        }
    }
}