namespace SRS.DataPersistence
{
	public abstract class DataSerializer
	{
		public abstract string Serialize(object data);

		public abstract object Deserialize(string data);
	}
}