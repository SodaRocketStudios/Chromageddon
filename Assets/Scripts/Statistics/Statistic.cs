using System;
using UnityEngine;
using SRS.DataPersistence;

namespace SRS.Statistics
{
	[Serializable]
	public class Statistic : IPersist
	{
		[SerializeField] private string name;
		public string Name
		{
			get => name;
		}

		private float value;
		public float Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
				OnValueChange?.Invoke(value);
			}
		}

		public Action<float> OnValueChange;

		[SerializeField] private float defaultValue;

		[SerializeField] private int decimalPlaces;

		[SerializeField] private bool isPersistent; 

		public Statistic(string name, float defaultValue = 0, int decimalPlaces = 0, bool isPersistent = false)
		{
			this.defaultValue = defaultValue;
			this.decimalPlaces = decimalPlaces;
			this.name = name;
			this.isPersistent = isPersistent;
			Reset();
		}

		public void Reset()
		{
			Value = defaultValue;
		}

		public void SetPersistence(bool persist)
		{
			isPersistent = persist;
		}

        public string GetFormattedValue()
        {
			// TODO -- revisit this to make sure it is what I want.
            return Value.ToString("N" + decimalPlaces);
        }

        public object CaptureState()
        {
            return new StatisticData()
			{
				Name = name,
				Value = value,
				DefaultValue = defaultValue,
				DecimalPlaces = decimalPlaces,
				IsPersistent = isPersistent
			};
        }

        public void RestoreState(object state)
        {
			StatisticData data = (StatisticData)state;
			
			name = data.Name;
			Value = data.Value;
			defaultValue = data.DefaultValue;
			decimalPlaces = data.DecimalPlaces;
			isPersistent = data.IsPersistent;

			if(isPersistent == false)
			{
				Reset();
			}
        }

		private struct StatisticData
		{
			public string Name;
			public float Value;
			public float DefaultValue;
			public int DecimalPlaces;
			public bool IsPersistent;
		}
    }
}