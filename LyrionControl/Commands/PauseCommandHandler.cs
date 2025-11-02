using System.Collections;

namespace LyrionControl.JsonRpcClient.Commands
{
    public class PauseCommandHandler
    {        
        private readonly RpcClient rpcClient;

        public PauseCommandHandler(HttpClient httpClient)
        {            
            rpcClient = new RpcClient(httpClient);
        }

        public Task<PlayCommand> Handle(string playerId)
        {
            var request = new PauseCommand
            {
                Method = "slim.request",
                Params = new ArrayList { playerId, new List<string>() { "pause" } }
            };
            
            return rpcClient.MakeRequest<PlayCommand>(request);
        }       
    }
}
