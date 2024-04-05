using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LmsMaui.JsonRpcClient.Queries
{
    public class ArtistsQuery : IRequest
    {
        [JsonPropertyName("method")]
        public string Method { get; set; }
        [JsonPropertyName("params")]
        public ArrayList Params { get; set; }
    }
}
