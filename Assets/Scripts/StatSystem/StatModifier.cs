using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatSystem
{
	[System.Serializable]
	public class StatModifier
	{
		[SerializeField] private List<float> values = new(5);
		public List<float> Values
		{
			get {return values;}
		}

		public StatModifier(List<float> values)
		{
			this.values = values;
		}
	}
}