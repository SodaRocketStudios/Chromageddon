using UnityEngine;

namespace SRS.Progression
{
	[CreateAssetMenu(fileName = "New Exponential Function", menuName = "Progression/Functions/Exponential Function")]
    public class ExponentialFunction : ProgressionFunction
    {
		[SerializeField] private float Exponent;

        public override float Compute(float previousValue)
        {
            return Mathf.Pow(previousValue, Exponent);
        }
    }
}