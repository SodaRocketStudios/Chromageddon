namespace SRS.Extensions
{
	public static class FloatExtensions
	{
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