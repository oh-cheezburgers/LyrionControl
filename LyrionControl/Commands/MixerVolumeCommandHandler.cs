using System.Collections;

namespace LyrionControl.JsonRpcClient.Commands
{
    public class MixerVolumeCommandHandler
    {        
        private readonly RpcClient rpcClient;

        public MixerVolumeCommandHandler(HttpClient httpClient)
        {            
            rpcClient = new RpcClient(httpClient);
        }

        public Task<MixerVolumeCommand> Handle(string playerId, string volume)
        {
            var request = new StopCommand
            {
                Method = "slim.request",
                Params = new ArrayList { playerId, new List<string>() { "mixer", "volume", volume } }
            };
            
            return rpcClient.MakeRequest<MixerVolumeCommand>(request);
        }       
    }
}
