using LyrionControl.JsonRpcClient.JsonConverters;
using LyrionControl.JsonRpcClient.Queries;
using System.Text.Json.Serialization;

namespace LyrionControl.JsonRpcClient.Responses
{
    public class StatusResponse : StatusQuery
    {
        [JsonPropertyName("result")]
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public Result? _Result { get; set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores

        public sealed class Result
        {
            [JsonPropertyName("seq_no")]
            public int SeqNo { get; set; }

            [JsonPropertyName("mixer volume")]
            public int MixerVolume { get; set; }

            [JsonPropertyName("player_name")]
            public string? PlayerName { get; set; }

            [JsonPropertyName("playlist_tracks")]
            public int PlaylistTracks { get; set; }

            [JsonPropertyName("player_connected")]
            public int PlayerConnected { get; set; }

            [JsonPropertyName("time")]
            public double Time { get; set; }

            [JsonPropertyName("mode")]
            public string? Mode { get; set; }

            [JsonPropertyName("playlist_timestamp")]
            public double PlaylistTimestamp { get; set; }

            [JsonPropertyName("rate")]
            public int Rate { get; set; }

            [JsonPropertyName("can_seek")]
            public int CanSeek { get; set; }

            [JsonPropertyName("power")]
            public int Power { get; set; }

            [JsonPropertyName("playlist_mode")]
            public string? PlaylistMode { get; set; }

            [JsonPropertyName("playlist_repeat")]
            public int PlaylistRepeat { get; set; }

            [JsonPropertyName("duration")]
            public double Duration { get; set; }

            [JsonPropertyName("playlist_cur_index")]
            [JsonConverter(typeof(EverythingToStringJsonConverter))]
            public string? PlaylistCurIndex { get; set; }

            [JsonPropertyName("signalstrength")]            
            public int SignalStrength { get; set; }

            [JsonPropertyName("digital_volume_control")]
            public int DigitalVolumeControl { get; set; }

            [JsonPropertyName("playlist_shuffle")]
            public int PlaylistShuffle { get; set; }

            [JsonPropertyName("player_ip")]
            public string? PlayerIp { get; set; }
        }       
    }
}
