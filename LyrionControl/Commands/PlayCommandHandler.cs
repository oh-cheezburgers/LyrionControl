using System.Collections;

namespace LyrionControl.JsonRpcClient.Commands
{
    public class PlayCommandHandler
    {        
        private readonly RpcClient rpcClient;

        public PlayCommandHandler(HttpClient httpClient)
        {            
            rpcClient = new RpcClient(httpClient);
        }

        public Task<PlayCommand> Handle(string playerId)
        {
            var request = new PlayCommand
            {
                Method = "slim.request",
                Params = new ArrayList { playerId, new List<string>() { "play" } }
            };
            
            return rpcClient.MakeRequest<PlayCommand>(request);
        }       
    }
}
