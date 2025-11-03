using System.Text.Json.Serialization;

namespace LyrionControl.JsonRpcClient.Responses
{
    public class AlbumsResponse : RequestEcho
    {
        [JsonPropertyName("result")]
        public AlbumsResult? Result { get; set; }
    }

    public class AlbumsResult
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("albums_loop")]
        public List<Album>? AlbumsLoop { get; set; }
    }

    public class Album
    {
        [JsonPropertyName("album")]
        public string? Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
