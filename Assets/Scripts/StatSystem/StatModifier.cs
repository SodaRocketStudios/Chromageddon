using UnityEngine;

namespace SRS.StatSystem
{
	[System.Serializable]
	public class StatModifier
	{
		[SerializeField] private float value;
		public float Value
		{
			get {return value;}
		}

		public StatModifier(float value)
		{
			this.value = value;
		}
	}
}