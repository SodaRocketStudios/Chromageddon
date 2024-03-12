using System.Collections.Generic;
using Newtonsoft.Json;

namespace SRS.Utils
{
	public static class DictionaryConverter
	{
		public static Dictionary<string, T> ToDictionary<T>(this object obj)
		{
			string json = JsonConvert.SerializeObject(obj);
			return JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
		}
	}
}