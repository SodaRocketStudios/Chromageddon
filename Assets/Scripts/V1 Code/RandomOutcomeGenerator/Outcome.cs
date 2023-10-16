namespace SRS.RandomOutcomeGenerator
{
	[System.Serializable]
	public class Outcome<T>
	{
		public T Result;
		public float DropRate;

		public Outcome(T result, float dropRate)
		{
			Result = result;
			DropRate = dropRate;
		}
	}
}