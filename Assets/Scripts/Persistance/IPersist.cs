namespace SRS.DataPersistence
{
	public interface IPersist
	{
		object CaptureState();
		void RestoreState(object state);
	}
}