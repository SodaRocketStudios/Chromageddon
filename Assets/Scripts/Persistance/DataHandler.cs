namespace SRS.DataPersistence
{
	public abstract class DataHandler
	{
		public abstract string Read(string location);

		public abstract void Write(string location, string data);
	}
}