using LmsMaui.JsonRpcClient.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LmsMaui.JsonRpcClient.Responses
{
    public class ArtistsResponse : ArtistsQuery
    {
        [JsonPropertyName("result")]
        public Result _Result { get; set; }
        public sealed class Result
        {
            [JsonPropertyName("count")]
            public int Count { get; set; }

            [JsonPropertyName("artists_loop")]
            public List<Artist> ArtistsLoop { get; set; }
        }

        public class Artist
        {
            [JsonPropertyName("artist")]
            public string _Artist { get; set; }

            [JsonPropertyName("id")]
            [JsonConverter(typeof(EverythingToStringJsonConverter))]
            public string Id { get; set; }
        }
    }
}
