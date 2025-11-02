using System.Collections;

namespace LyrionControl.JsonRpcClient.Commands
{
    public class StopCommandHandler
    {        
        private readonly RpcClient rpcClient;

        public StopCommandHandler(HttpClient httpClient)
        {            
            rpcClient = new RpcClient(httpClient);
        }

        public Task<StopCommand?> HandleAsync(string playerId)
        {
            var request = new StopCommand
            {
                Method = "slim.request",
                Params = new ArrayList { playerId, new List<string>() { "stop" } }
            };
            
            return rpcClient.MakeRequestAsync<StopCommand>(request);
        }       
    }
}
