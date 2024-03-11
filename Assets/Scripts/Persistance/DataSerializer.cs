using System.Collections.Generic;

namespace SRS.DataPersistence
{
	public abstract class DataSerializer
	{
		public abstract string Serialize(Dictionary<string, object> data);

		public abstract Dictionary<string, object> Deserialize(string data);
	}
}