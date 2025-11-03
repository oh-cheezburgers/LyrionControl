using System.Collections;
using System.Text.Json.Serialization;

namespace LyrionControl.JsonRpcClient
{
    public class RequestEcho
    {
        [JsonPropertyName("method")]
        public string? Method { get; set; }

        [JsonPropertyName("params")]
        public ArrayList? Params { get; set; }
    }
}