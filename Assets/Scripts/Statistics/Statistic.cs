using UnityEngine;

namespace SRS.Statistics
{
	public class Statistic
	{
		[SerializeField] private string name;
		public string Name
		{
			get => name;
		}

		public float Value{get; set;}

		[SerializeField] private float defaultValue;

		[SerializeField] private int decimalPlaces;

		public Statistic(string name, float defaultValue = 0, int decimalPlaces = 0)
		{
			this.defaultValue = defaultValue;
			this.decimalPlaces = decimalPlaces;
			this.name = name;
			Reset();
		}

		public void Reset()
		{
			Value = defaultValue;
		}

        public override string ToString()
        {
			// TODO -- revisit this to make sure it is what I want.
            return Value.ToString("N" + decimalPlaces);
        }
    }
}