using System.Text.Json.Serialization;
using LyrionControl.JsonRpcClient.Queries;

namespace LyrionControl.JsonRpcClient.Responses
{
    public class AlbumsResponse : AlbumsQuery
    {
        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }

    public sealed class Result
    {
        [JsonPropertyName("count")]
        public int Count { get; init; }

        [JsonPropertyName("albums_loop")]
        public List<Albums> AlbumsLoop { get; set; }
    }

    public sealed class Albums
    {
        [JsonPropertyName("album")]
        public string Album { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("artwork_track_id")]
        public string ArtworkTrackId { get; set; }
    }
}
