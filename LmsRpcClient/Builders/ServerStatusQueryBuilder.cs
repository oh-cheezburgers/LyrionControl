using LyrionControl.JsonRpcClient.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var list = (List<string>)request.Params[1];
            list.Insert(1, start.ToString());
            return this;
        }

        public ServerStatusQueryBuilder ItemsPerResponse(int itemsPerResponse)
        {
            var list = (List<string>)request.Params[1];
            list.Insert(2, itemsPerResponse.ToString());
            return this;
        }

        public ServerStatusQuery Build()
        {
            return request;
        }
    }
}
