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

		private float value;
		public float Value
		{
			get
			{
				if(isDirty)
				{
					value =  (BaseValue + AdditiveModifier)*MultiplicativeModifier + FlatModifier;
					isDirty = false;
				}
				return value;
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
				isDirty = true;
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
				isDirty = true;
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
				isDirty = true;
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
				isDirty = true;
			}
		}

		private bool isDirty = true;

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