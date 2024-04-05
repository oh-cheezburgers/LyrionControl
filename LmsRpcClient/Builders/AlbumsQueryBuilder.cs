using System;
using System.Collections;
using LmsMaui.JsonRpcClient.Queries;

namespace LmsMaui.JsonRpcClient.Builders
{
    public class AlbumsQueryBuilder
    {
        private readonly AlbumsQuery request;
        private List<string> tags = new List<string>();
        private string artistId;

        public AlbumsQueryBuilder()
        {
            request = new AlbumsQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    "",
                    new List<string>
                    {
                        QueryTypes.Albums
                    }
                }
            };
        }

        public AlbumsQueryBuilder Start(int start)
        {
            var list = (List<string>)request.Params[1];
            list.Insert(1, start.ToString());
            return this;
        }

        public AlbumsQueryBuilder ItemsPerResponse(int itemsPerResponse)
        {
            var list = (List<string>)request.Params[1];
            list.Insert(2, itemsPerResponse.ToString());
            return this;
        }

        public AlbumsQueryBuilder ByArtistId(string id)
        {
            this.artistId = id;
            return this;
        }

        public AlbumsQueryBuilder WithTitle()
        {
            tags.Add("t");
            return this;
        }

        public AlbumsQueryBuilder WithArtworTrackId() 
        {
            tags.Add("j");
            return this;
        }

        public AlbumsQuery Build()
        {
            var list = (List<string>)request.Params[1];
            if (!string.IsNullOrWhiteSpace(artistId))
            {
                list.Add("artist_id:" + artistId);
            }            
            if (tags.Count > 0)
            {
                var tagsString = "tags: " + String.Join(",", tags);                
                list.Add(tagsString);
            }
            return request;
        }

        public AlbumsQueryBuilder WithSearchTerm(string term)
        {
            var list = (List<string>)request.Params[1];
            list.Add("search:" + term);
            return this;
        }

    }
}
