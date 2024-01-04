using UnityEngine;

namespace SRS.Progression
{	
	public abstract class ProgressionFunction : ScriptableObject
	{
		public abstract float Initialize(float previousValue);
		public abstract float Compute(float previousValue);
	}
}