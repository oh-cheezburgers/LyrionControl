using System.Collections;

namespace LyrionControl.JsonRpcClient.Commands
{
    public class PlaylistCommandHandler
    {        
        private readonly RpcClient rpcClient;

        public PlaylistCommandHandler(HttpClient httpClient)
        {            
            rpcClient = new RpcClient(httpClient);
        }

        public Task<PlaylistCommand> Index(string playerId, string index)
        {
            var request = new PauseCommand
            {
                Method = "slim.request",
                Params = new ArrayList { playerId, new List<string>() { "playlist", "index", index } }
            };
            
            return rpcClient.MakeRequest<PlaylistCommand>(request);
        }
        
        public Task<PlaylistCommand> Play(string playerId, string url)
        {
            var request = new PauseCommand
            {
                Method = "slim.request",
                Params = new ArrayList { playerId, new List<string>() { "playlist", "play", url } }
            };

            return rpcClient.MakeRequest<PlaylistCommand>(request);
        }
    }
}
