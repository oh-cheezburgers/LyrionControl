using System.Collections;

namespace LyrionControl.JsonRpcClient.Commands
{
    public class TimeCommandHandler
    {        
        private readonly RpcClient rpcClient;

        public TimeCommandHandler(HttpClient httpClient)
        {            
            rpcClient = new RpcClient(httpClient);
        }

        public Task<TimeCommand?> HandleAsync(string playerId, string time)
        {
            var request = new StopCommand
            {
                Method = "slim.request",
                Params = new ArrayList { playerId, new List<string>() { "time", time } }
            };
            
            return rpcClient.MakeRequestAsync<TimeCommand>(request);
        }       
    }
}
