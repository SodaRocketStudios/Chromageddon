using System;
using UnityEngine;

namespace SRS.Utils
{
	[Serializable]
	public class IntRange : IEquatable<IntRange>
	{
		public Action OnMaxChange;
		public Action OnMinChange;
		public Action OnValueChange;

		protected int current;
		public int Current
		{
			get => current;
			set
			{
				current = Mathf.Clamp(value, min, max);
			}
		}

		[SerializeField] protected int min;
		public int Min
		{
			get => min;
			set => min = value;
		}

		[SerializeField] protected int max;
		public int Max
		{
			get => max;
			set => max = value;
		}

        public bool Equals(IntRange other)
        {
            return other.Current == current?true:false;
        }
    }
}