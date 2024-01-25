using System;
using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace SRS.Utils
{
	public abstract class RangedValue<T> where T : IEquatable<T>
	{
		// There is no easy way to limit generics to only numbers in c#.
		public Action OnMaxChange;
		public Action OnMinChange;
		public Action OnValueChange;

		protected T value;
		public T Value
		{
			get => value;
			set
			{
			}
		}

		protected T max;
		public T Max
		{
			get => max;
			set => max = value;
		}

		protected T min;
		public T Min
		{
			get => min;
			set => min = value;
		}
	}
}