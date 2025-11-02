using LyrionControl.JsonRpcClient.Queries;
using System.Collections;
using System.Globalization;

namespace LyrionControl.JsonRpcClient.Builders
{    
    public class ServerStatusQueryBuilder
    {
        private readonly ServerStatusQuery request;

        public ServerStatusQueryBuilder()
        {
            request = new ServerStatusQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    string.Empty,
                    new List<string>
                    {
                        QueryTypes.ServerStatus
                    }
                }
            };
        }

        public ServerStatusQueryBuilder Start(int start)
        {
            if (request.Params != null)
            {
                var list = request.Params[1] as List<string>;
                list?.Insert(1, start.ToString(CultureInfo.InvariantCulture));
            }            
            return this;
        }

        public ServerStatusQueryBuilder ItemsPerResponse(int itemsPerResponse)
        {
            if (request.Params != null)
            {
                var list = (List<string>?)request.Params[1];
                list?.Insert(2, itemsPerResponse.ToString(CultureInfo.InvariantCulture));
            }            
            return this;
        }

        public ServerStatusQuery Build()
        {
            return request;
        }
    }
}
