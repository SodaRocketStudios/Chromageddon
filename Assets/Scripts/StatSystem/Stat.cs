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
		[SerializeField] private float additiveModifier;
		[SerializeField] private float percentageModifier;
		[SerializeField] private float flatModifier;

		private float value;
		public float Value
		{
			get
			{
				if(isDirty)
				{
					value = (baseValue + additiveModifier)*percentageModifier + flatModifier;
					isDirty = false;
				}

				return value;
			}
		}


		private bool isDirty = true;

		public Stat(string name, float baseValue = 1, float additiveModifier = 0, float percentageModifier = 0, float flatModifier = 0)
		{
			Name = name;
			this.baseValue = baseValue;
			this.additiveModifier = additiveModifier;
			this.percentageModifier = percentageModifier;
			this.flatModifier = flatModifier;
		}

		public void AddModifier(StatModifier modifier)
		{
			switch(modifier.Type)
			{
				case ModifierType.Additive:
					additiveModifier += modifier.Value;
					break;
				case ModifierType.Percentage:
					percentageModifier += modifier.Value*.01f;
					break;
				case ModifierType.Flat:
					flatModifier += modifier.Value;
					break;
				default:
					break;
			}

			isDirty = true;
		}

		public void RemoveModifier(StatModifier modifier)
		{
			switch(modifier.Type)
			{
				case ModifierType.Additive:
					additiveModifier -= modifier.Value;
					break;
				case ModifierType.Percentage:
					percentageModifier -= modifier.Value*.01f;
					break;
				case ModifierType.Flat:
					flatModifier -= modifier.Value;
					break;
				default:
					break;
			}

			isDirty = true;
		}

		public Stat DeepCopy()
		{
			return new Stat(name, baseValue, additiveModifier, percentageModifier, flatModifier);
		}
	}
}