using System.Collections;
using System.Text.Json.Serialization;

namespace LyrionControl.JsonRpcClient
{
    public class Request : IRequest
    {
        [JsonPropertyName("method")]
        public string? Method { get; set; } = RpcMethod.SlimRequest;

        [JsonPropertyName("params")]
        public ArrayList? Params { get; set; }
    }
}