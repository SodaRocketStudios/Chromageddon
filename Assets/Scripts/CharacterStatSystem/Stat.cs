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

		public float Value
		{
			get
			{
				return (BaseValue + AdditiveModifier)*MultiplicativeModifier + FlatModifier;
			}
		}

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
			}
		}

		public Stat(string _name, float _baseValue = 1, float _additiveModifier = 0, float _multiplicativeModifier = 1, float _flatModifier = 0)
		{
			Name = _name;
			BaseValue = _baseValue;
			AdditiveModifier = _additiveModifier;
			MultiplicativeModifier = _multiplicativeModifier;
			FlatModifier = _flatModifier;
		}

		public Stat(Stat stat)
		{
			Name = stat.Name;
			BaseValue = stat.BaseValue;
			AdditiveModifier = stat.AdditiveModifier;
			MultiplicativeModifier = stat.MultiplicativeModifier;
			FlatModifier = stat.FlatModifier;
		}
	}
}