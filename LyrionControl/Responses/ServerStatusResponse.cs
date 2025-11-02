using System.Text.Json.Serialization;
using LyrionControl.JsonRpcClient.JsonConverters;
using LyrionControl.JsonRpcClient.Queries;

namespace LyrionControl.JsonRpcClient.Responses
{
    public class ServerStatusResponse : ServerStatusQuery
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public Result? _Result { get; set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores

        public sealed class Result
        {
            [JsonPropertyName("version")]
            public string? Version { get; set; }

            [JsonPropertyName("info total albums")]
            public int InfoTotalAlbums { get; set; }

            [JsonPropertyName("info total duration")]
            public decimal? InfoTotalDuration { get; set; }

            [JsonPropertyName("player count")]
            public int PlayerCount { get; set; }

            [JsonPropertyName("lastscan")]
            public long LastScan { get; set; }

            [JsonPropertyName("info total artists")]
            public int InfoTotalArtists { get; set; }

            [JsonPropertyName("httpport")]
            public int HttpPort { get; set; }

            [JsonPropertyName("ip")]
            public string? IP { get; set; }

            [JsonPropertyName("uuid")]
            public Guid UUID { get; set; }

            [JsonPropertyName("info total songs")]
            public int InfoTotalSongs { get; set; }

            [JsonPropertyName("sn player count")]
            public int SnPlayerCount { get; set; }

            [JsonPropertyName("other player count")]
            public int OtherPlayerCount { get; set; }

            [JsonPropertyName("info total genres")]
            public int InfoTotalGenres { get; set; }

            [JsonPropertyName("players_loop")]
            public List<Player>? PlayersLoop { get; set; }
        }   

        public class Player
        {
            [JsonPropertyName("seq_no")]
            public int SeqNo { get; set; }

            [JsonPropertyName("playerid")]
            public string? PlayerId { get; set; }

            [JsonPropertyName("displaytype")]
            public string? DisplayType { get; set; }

            [JsonPropertyName("connected")]
            public int Connected { get; set; }

            [JsonPropertyName("ip")]
            public string? Ip { get; set; }

            [JsonPropertyName("model")]
            public string? Model { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("firmware")]
            [JsonConverter(typeof(EverythingToStringJsonConverter))]
            public string? Firmware { get; set; }

            [JsonPropertyName("uuid")]
            public object? Uuid { get; set; }

            [JsonPropertyName("isplayer")]
            public int IsPlayer { get; set; }

            [JsonPropertyName("canpoweroff")]
            public int CanPowerOff { get; set; }

            [JsonPropertyName("isplaying")]
            public int IsPlaying { get; set; }

            [JsonPropertyName("playerindex")]
            public string? PlayerIndex { get; set; }

            [JsonPropertyName("power")]
            public int Power { get; set; }

            [JsonPropertyName("modelname")]
            public string? ModelName { get; set; }
        }

    }
}