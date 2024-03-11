using System.Collections.Generic;
using Newtonsoft.Json;

namespace SRS.DataPersistence
{
    public class JsonDataSerializer : DataSerializer
    {
        public override string Serialize(Dictionary<string, object> data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public override Dictionary<string, object> Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
        }
    }
}