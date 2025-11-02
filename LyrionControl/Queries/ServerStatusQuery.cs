using System.Collections;
using System.Text.Json.Serialization;

namespace LyrionControl.JsonRpcClient.Queries
{
    public class ServerStatusQuery : IRequest
    {
        [JsonPropertyName("method")]
        public string? Method { get; set; }
        [JsonPropertyName("params")]
        public ArrayList? Params { get; set; }
    }
}