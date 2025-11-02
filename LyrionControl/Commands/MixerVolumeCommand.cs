using System.Collections;
using System.Text.Json.Serialization;

namespace LyrionControl.JsonRpcClient.Commands
{
    public class MixerVolumeCommand : IRequest
    {
        [JsonPropertyName("method")]
        public string? Method { get; set; }
        [JsonPropertyName("params")]
        public ArrayList? Params { get; set; }       
        
    }
}
