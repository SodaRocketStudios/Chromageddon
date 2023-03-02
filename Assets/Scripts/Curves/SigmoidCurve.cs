using UnityEngine;

namespace SRS.Curves
{
	public class SigmoidCurve
	{
		private float L;
		private float x0;
		private float y0;
		private float k;

		public SigmoidCurve(float asymptote = 1, float horizontalShift = 0, float verticalShift = 0, float growthRate = 1)
		{
			this.L = asymptote;
			this.x0 = horizontalShift;
			this.y0 = verticalShift;
			this.k = growthRate;
		}

		public float Sample(float x)
		{
			return L/(1 + Mathf.Exp(-k * (x - x0))) - y0;
		}
	}
}