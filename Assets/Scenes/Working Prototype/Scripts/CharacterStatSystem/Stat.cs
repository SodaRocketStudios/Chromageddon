using UnityEngine;

namespace SRS.Stats
{
	[System.Serializable]
	public class Stat
	{
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

		public float Value {get; private set;}

		[SerializeField]
		private float baseValue;
		public float BaseValue
		{
			private get
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
			private get
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
			private get
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
			private get
			{
				return flatModifier;
			}
			set
			{
				flatModifier = value;
				OnValueChange();
			}
		}

		public Stat(string _name, float _baseValue, float _additiveModifier = 0, float _multiplicativeModifier = 1, float _flatModifier = 0)
		{
			Name = _name;
			BaseValue = _baseValue;
			AdditiveModifier = _additiveModifier;
			MultiplicativeModifier = _multiplicativeModifier;
			FlatModifier = _flatModifier;
		}

		private void OnValueChange()
		{
			Value = (BaseValue + AdditiveModifier)*MultiplicativeModifier + FlatModifier;
		}
	}
}