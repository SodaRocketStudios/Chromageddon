using UnityEngine;

namespace SRS.StatSystem
{
	[System.Serializable]
	public class Stat
	{
		[SerializeField] private string name;
		public string Name
		{
			get
			{
				return name;
			}
			private set
			{
				name = value;
			}
		}

		[SerializeField] private float baseValue;
		public float BaseValue
		{
			get
			{
				return baseValue;
			}
			set
			{
				baseValue = value;
				updateValue();
				OnValueChange?.Invoke(Value);
			}
		}

		[SerializeField] private float percentageModifier;
		public float PercentageModifier
		{
			get
			{
				return percentageModifier;
			}
			set
			{
				percentageModifier = value;
				updateValue();
				OnValueChange?.Invoke(Value);
			}
		}

		[SerializeField] private bool hasCap = false;
		public bool HasCap { get {return hasCap;} }

		[SerializeField] private float cap = 0;
		public float ValueCap { get {return cap;} }

		public delegate void valueChangeHandler(float value);

		[HideInInspector] public event valueChangeHandler OnValueChange;

		private float value;
		public float Value
		{
			get
			{
				return value;
			}
		}

		public Stat(string name, float baseValue = 1, float percentageModifier = 100)
		{
			Name = name;
			this.baseValue = baseValue;
			this.percentageModifier = percentageModifier;
		}

		private void updateValue()
		{
			value = baseValue*percentageModifier*.01f;

			if(hasCap)
			{
				value = Mathf.Min(value, cap);
			}
		}

		public Stat DeepCopy()
		{
			return new Stat(name, baseValue, percentageModifier);
		}
	}
}