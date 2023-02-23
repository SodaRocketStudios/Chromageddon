using UnityEngine;

namespace SRS.StatSystem
{
	[System.Serializable]
	public class StatModifier
	{
		[SerializeField] private ModifierType type;
		public ModifierType Type
		{
			get {return type;}
		}

		[SerializeField] private float value;
		public float Value
		{
			get {return value;}
		}

		public StatModifier(ModifierType type, float value)
		{
			this.type = type;
			this.value = value;
		}
	}

	public enum ModifierType
	{
		Additive,
		Percentage,
		Multiplier
	}
}