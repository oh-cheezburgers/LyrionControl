using System.Text.Json.Serialization;
using LmsMaui.JsonRpcClient.Queries;

namespace LmsMaui.JsonRpcClient.Responses
{
    public class PlayersResponse : PlayersQuery
    {
        public Result result { get; set; }
        public sealed class Result
        {
            [JsonPropertyName("count")]
            public int Count { get; init; }

            [JsonPropertyName("players_loop")]
            public List<Player> PlayersLoop { get; set; }
        }
        public sealed class Player
        {
            [JsonPropertyName("seq_no")]
            public int SeqNo { get; set; }

            [JsonPropertyName("playerid")]
            public string PlayerId { get; set; }

            [JsonPropertyName("displaytype")]
            public string DisplayType { get; set; }

            [JsonPropertyName("connected")]
            public int Connected { get; set; }

            [JsonPropertyName("ip")]
            public string IP { get; set; }

            [JsonPropertyName("model")]
            public string Model { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonConverter(typeof(EverythingToStringJsonConverter))]
            [JsonPropertyName("firmware")]
            public string Firmware { get; set; }

            [JsonPropertyName("uuid")]
            public string UUID { get; set; }

            [JsonPropertyName("isplayer")]
            public int IsPlayer { get; set; }

            [JsonPropertyName("canpoweroff")]
            public int CanPowerOff { get; set; }

            [JsonPropertyName("isplaying")]
            public int IsPlaying { get; set; }

            [JsonPropertyName("playerindex")]
            public int PlayerIndex { get; set; }

            [JsonPropertyName("power")]
            public int Power { get; set; }

            [JsonPropertyName("modelname")]
            public string ModelName { get; set; }
        }
    }
}