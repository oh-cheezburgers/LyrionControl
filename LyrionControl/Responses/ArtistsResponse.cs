using LyrionControl.JsonRpcClient.JsonConverters;
using LyrionControl.JsonRpcClient.Queries;
using System.Text.Json.Serialization;

namespace LyrionControl.JsonRpcClient.Responses
{
    public class ArtistsResponse : ArtistsQuery
    {
        [JsonPropertyName("result")]
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public Result? _Result { get; set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores

        public sealed class Result
        {
            [JsonPropertyName("count")]
            public int Count { get; set; }

            [JsonPropertyName("artists_loop")]
            public List<Artist>? ArtistsLoop { get; set; }
        }

        public class Artist
        {
            [JsonPropertyName("artist")]
            public required string Name { get; set; }

            [JsonPropertyName("id")]
            [JsonConverter(typeof(EverythingToStringJsonConverter))]
            public required string Id { get; set; }
        }
    }
}
