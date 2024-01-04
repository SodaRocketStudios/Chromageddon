using UnityEngine;

namespace SRS.Progression
{	
	public abstract class ProgressionFunction : ScriptableObject
	{
		[SerializeField] protected float initialValue;
		public float GetInitialValue()
		{
			return initialValue;
		}
		public abstract float Compute(float previousValue);
	}
}