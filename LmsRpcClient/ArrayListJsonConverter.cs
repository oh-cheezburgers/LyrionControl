using System.Collections;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace LyrionControl.JsonRpcClient
{
    public class ArrayListJsonConverter : JsonConverter<ArrayList>
    {
        public override ArrayList Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var arrayList = new ArrayList();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.StartArray)
                {
                    arrayList.Add(JsonSerializer.Deserialize<List<string>>(ref reader));
                }
                else if (reader.TokenType == JsonTokenType.String)
                {
                    arrayList.Add(reader.GetString());
                }
                else if (reader.TokenType == JsonTokenType.EndObject || reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }
                else
                {
                    throw new JsonException();
                }
            }
            return arrayList;
        }

        public override void Write(Utf8JsonWriter writer, ArrayList value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
