using System.Collections;
using System.Text.Json.Serialization;

namespace LmsMaui.JsonRpcClient.Queries
{
    public class AlbumsQuery : IRequest
    {
        [JsonPropertyName("method")]
        public string Method { get; set; }
        [JsonPropertyName("params")]
        public ArrayList Params { get; set; }
    }
}