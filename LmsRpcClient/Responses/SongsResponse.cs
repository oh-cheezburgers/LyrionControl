using System.Text.Json.Serialization;
using LmsMaui.JsonRpcClient.Queries;

namespace LmsMaui.JsonRpcClient.Responses
{
    public class SongsResponse : SongsQuery
    {
        [JsonPropertyName("result")]
        public Result result { get; set; }

        public sealed class Result
        {
            [JsonPropertyName("count")]
            public int Count { get; init; }

            [JsonPropertyName("titles_loop")]
            public List<Song> TitlesLoop { get; set; }
        }

        public sealed class Song
        {

            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("genre")]
            public string Genre { get; set; }

            [JsonPropertyName("album")]
            public string Album { get; set; }

            [JsonPropertyName("duration")]
            public string Duration { get; set; }

            [JsonPropertyName("tracknum")]
            public string TrackNum { get; set; }

            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("artwork_track_id")]
            public string ArtworkTrackId { get; set; }

            [JsonPropertyName("album_id")]
            public string AlbumId { get; set; }

        }

    }   

}
