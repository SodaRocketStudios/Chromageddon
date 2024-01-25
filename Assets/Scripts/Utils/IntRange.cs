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

		[SerializeField] protected int current;
		public int Current
		{
			get => current;
			set
			{
				value = value <= min?min:value;
				current = value >= max?max:value;
			}
		}

		[SerializeField] protected int max;
		public int Max
		{
			get => max;
			set => max = value;
		}

		[SerializeField] protected int min;
		public int Min
		{
			get => min;
			set => min = value;
		}

        public bool Equals(IntRange other)
        {
            return other.Current == current?true:false;
        }
    }
}