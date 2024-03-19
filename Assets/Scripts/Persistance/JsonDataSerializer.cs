using Newtonsoft.Json;

namespace SRS.DataPersistence
{
    public class JsonDataSerializer : DataSerializer
    {
        public override string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public override object Deserialize(string data)
        {
            return JsonConvert.DeserializeObject(data);
        }
    }
}