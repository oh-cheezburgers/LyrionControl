using LyrionControl.JsonRpcClient.Queries;
using System.Collections;

namespace LyrionControl.JsonRpcClient.Builders
{
    public class StatusQueryBuilder
    {
        private readonly StatusQuery request;        
        public StatusQueryBuilder(string playerId)
        {
            request = new StatusQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    playerId,
                    new List<string>
                    {
                        QueryTypes.Status
                    }
                }
            };
        }

        public StatusQuery Build()
        {
            return request;
        }
    }
}
