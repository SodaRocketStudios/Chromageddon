namespace SRS.Extensions.Scalar
{
	public static class ScalarExtensions
	{
		public static float Fractional(this float value)
		{
			return value - (int)value;
		}

		public static int DecimalPlaces(this float num)
		{
			string[] digits = num.ToString().Split('.');

			if(digits.Length < 2)
			{
				return 0;
			}
			
			return digits[1].Length;
		}
	}
}