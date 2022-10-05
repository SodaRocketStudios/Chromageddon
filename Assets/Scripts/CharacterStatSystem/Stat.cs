using UnityEngine;

namespace SRS.Stats
{
	[System.Serializable]
	public class Stat
	{
		public delegate void UpdateValue(float value);
		public event UpdateValue onValueChanged;

		[SerializeField]
		private string name;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public float Value{get; private set;}

		[SerializeField]
		private float baseValue;
		public float BaseValue
		{
			get
			{
				return baseValue;
			}
			set
			{
				baseValue = value;
				OnValueChange();
			}
		}

		[SerializeField]
		private float additiveModifier;
		public float AdditiveModifier
		{
			get
			{
				return additiveModifier;
			}
			set
			{
				additiveModifier = value;
				OnValueChange();
			}
		}

		[SerializeField]
		private float multiplicativeModifier;
		public float MultiplicativeModifier
		{
			get
			{
				return multiplicativeModifier;
			}
			set
			{
				multiplicativeModifier = value;
				OnValueChange();
			}
		}

		[SerializeField]
		private float flatModifier;
		public float FlatModifier
		{
			get
			{
				return flatModifier;
			}
			set
			{
				flatModifier = value;
				OnValueChange();
			}
		}

		public Stat(string _name, float _baseValue = 1, float _additiveModifier = 0, float _multiplicativeModifier = 1, float _flatModifier = 0)
		{
			Name = _name;
			BaseValue = _baseValue;
			AdditiveModifier = _additiveModifier;
			MultiplicativeModifier = _multiplicativeModifier;
			FlatModifier = _flatModifier;

			OnValueChange();
		}

		public Stat(Stat stat)
		{
			Name = stat.Name;
			BaseValue = stat.BaseValue;
			AdditiveModifier = stat.AdditiveModifier;
			MultiplicativeModifier = stat.MultiplicativeModifier;
			FlatModifier = stat.FlatModifier;

			OnValueChange();
		}

		private void OnValueChange()
		{
			Value = (BaseValue + AdditiveModifier)*MultiplicativeModifier + FlatModifier;
			onValueChanged?.Invoke(Value);
		}
	}
}