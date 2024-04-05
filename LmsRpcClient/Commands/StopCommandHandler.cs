using System.Collections;

namespace LmsMaui.JsonRpcClient.Commands
{
    public class StopCommandHandler
    {        
        private readonly RpcClient rpcClient;

        public StopCommandHandler(HttpClient httpClient)
        {            
            rpcClient = new RpcClient(httpClient);
        }

        public Task<StopCommand> Handle(string playerId)
        {
            var request = new StopCommand
            {
                Method = "slim.request",
                Params = new ArrayList { playerId, new List<string>() { "stop" } }
            };
            
            return rpcClient.MakeRequest<StopCommand>(request);
        }       
    }
}
