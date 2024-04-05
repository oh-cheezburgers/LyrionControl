using System;
using System.Collections;
using LmsMaui.JsonRpcClient.Queries;

namespace LmsMaui.JsonRpcClient.Builders
{
    public class PlayersQueryBuilder

    {
        private readonly PlayersQuery request;

        public PlayersQueryBuilder()
        {
            request = new PlayersQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    string.Empty,
                    new ArrayList
                    {
                        QueryTypes.Players
                    }
                }
            };
        }

        public PlayersQueryBuilder Start(int start)
        {
            ((ArrayList)request.Params[1]).Insert(1, start);
            return this;
        }

        public PlayersQueryBuilder ItemsPerResponse(int itemsPerResponse)
        {
            ((ArrayList)request.Params[1]).Insert(2, itemsPerResponse);
            return this;
        }

        public PlayersQuery Build()
        {
            return request;
        }

    }
}
