using LyrionControl.JsonRpcClient.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyrionControl.JsonRpcClient.Builders
{
    public class ArtistsQueryBuilder
    {
        private readonly ArtistsQuery request;
        private string roleId;
        public ArtistsQueryBuilder()
        {
            request = new ArtistsQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    "",
                    new List<string>
                    {
                        QueryTypes.Artists
                    }
                }
            };
        }

        public ArtistsQueryBuilder Start(int start)
        {
            var list = (List<string>)request.Params[1];
            list.Insert(1, start.ToString());
            return this;
        }

        public ArtistsQueryBuilder ItemsPerResponse(int itemsPerResponse)
        {
            var list = (List<string>)request.Params[1];
            list.Insert(2, itemsPerResponse.ToString());
            return this;
        }

        public ArtistsQueryBuilder WithRoleId(string roleId)
        {
            this.roleId = roleId;
            return this;
        }

        public ArtistsQuery Build()
        {
            if (!string.IsNullOrEmpty(roleId))
            {
                var list = (List<string>)request.Params[1];
                list.Add("role_id:" + roleId);
            }
            return request;
        }

        public ArtistsQueryBuilder WithSearchTerm(string term)
        {
            var list = (List<string>)request.Params[1];
            list.Add("search:" + term);
            return this;
        }
    }
}
