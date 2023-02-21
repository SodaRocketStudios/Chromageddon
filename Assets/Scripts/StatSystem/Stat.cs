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
		[SerializeField] private float percentageModifier;
		
		private bool isDirty = true;

		private float value;
		public float Value
		{
			get
			{
				if(isDirty)
				{
					value = baseValue*percentageModifier*.01f;
					isDirty = false;
				}

				return value;
			}
		}

		public Stat(string name, float baseValue = 1, float percentageModifier = 100)
		{
			Name = name;
			this.baseValue = baseValue;
			this.percentageModifier = percentageModifier;
		}

		public void AddModifier(StatModifier modifier)
		{
			switch(modifier.Type)
			{
				case ModifierType.Additive:
					baseValue += modifier.Value;
					break;
				case ModifierType.Percentage:
					percentageModifier += modifier.Value;
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
					baseValue -= modifier.Value;
					break;
				case ModifierType.Percentage:
					percentageModifier -= modifier.Value;
					break;
				default:
					break;
			}

			isDirty = true;
		}

		public Stat DeepCopy()
		{
			return new Stat(name, baseValue, percentageModifier);
		}
	}
}