using LyrionControl.JsonRpcClient.Queries;
using System.Collections;
using System.Globalization;

namespace LyrionControl.JsonRpcClient.Builders
{
    public class ArtistsQueryBuilder
    {
        private readonly ArtistsQuery request;
        private string? roleId;
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
            if (request.Params != null)
            {
                var list = (List<string>?)request.Params[1];
                list?.Insert(1, start.ToString(CultureInfo.InvariantCulture));
            }
            return this;
        }

        public ArtistsQueryBuilder ItemsPerResponse(int itemsPerResponse)
        {
            if (request.Params != null)
            {
                var list = (List<string>?)request.Params[1];
                list?.Insert(2, itemsPerResponse.ToString(CultureInfo.InvariantCulture));
            }
            return this;
        }

        public ArtistsQueryBuilder WithRoleId(string roleId)
        {
            this.roleId = roleId;
            return this;
        }

        public ArtistsQuery Build()
        {
            if (request.Params != null)
            {
                if (!string.IsNullOrEmpty(roleId))
                {
                    var list = (List<string>?)request.Params[1];
                    list?.Add("role_id:" + roleId);
                }
            }
            return request;
        }

        public ArtistsQueryBuilder WithSearchTerm(string term)
        {
            if (request.Params != null)
            {
                var list = (List<string>?)request.Params[1];
                list?.Add("search:" + term);
            }
            return this;
        }
    }
}
