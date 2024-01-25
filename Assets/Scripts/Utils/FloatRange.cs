using System;

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
				value = value <= min?min:value;
				this.current = value >= max?max:value;
			}
		}

		protected float max;
		public float Max
		{
			get => max;
			set => max = value;
		}

		protected float min;
		public float Min
		{
			get => min;
			set => min = value;
		}
	}
}