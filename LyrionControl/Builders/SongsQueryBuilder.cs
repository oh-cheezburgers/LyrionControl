using LyrionControl.JsonRpcClient.Queries;
using System.Collections;
using System.Globalization;

namespace LyrionControl.JsonRpcClient.Builders
{
    public class SongsQueryBuilder
    {
        private readonly SongsQuery request;
        private string? albumId;
        private List<string> tags = new List<string>();

        public SongsQueryBuilder()
        {
            request = new SongsQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    string.Empty,
                    new List<string>
                    {
                        QueryTypes.Songs
                    }
                }
            };
        }

        public SongsQueryBuilder Start(int start)
        {
            if (request.Params != null)
            {
                var list = (List<string>?)request.Params[1];
                list?.Insert(1, start.ToString(CultureInfo.InvariantCulture));
            }
            return this;
        }

        public SongsQueryBuilder ItemsPerResponse(int itemsPerResponse)
        {
            if (request.Params != null)
            {
                var list = (List<string>?)request.Params[1];
                list?.Insert(2, itemsPerResponse.ToString(CultureInfo.InvariantCulture));
            }
            return this;
        }

        public SongsQueryBuilder WithAlbumId(int albumId)
        {
            this.albumId = albumId.ToString(CultureInfo.InvariantCulture);
            return this;
        }

        public SongsQueryBuilder WithTrackNumber()
        {
            tags.Add("t");
            return this;
        }

        public SongsQueryBuilder WithDuration()
        {
            tags.Add("d");
            return this;
        }
        public SongsQueryBuilder WithUrl()
        {
            tags.Add("u");
            return this;
        }

        public SongsQueryBuilder WithAlbumIdTag()
        {
            tags.Add("e");
            return this;
        }

        public SongsQueryBuilder WithSearchTerm(string term)
        {
            if (request.Params != null)
            {
                var list = (List<string>?)request.Params[1];
                list?.Add("search:" + term);
            }
            return this;
        }

        public SongsQueryBuilder WithArtworTrackId()
        {
            tags.Add("J");
            return this;
        }

        public SongsQuery Build()
        {
            if (request.Params != null)
            {
                var list = (List<string>?)request.Params[1];
                list?.Insert(3, $"album_id:{albumId}");
                if (tags.Count > 0)
                {
                    list?.Insert(4, $"tags:{string.Join(",", tags)}");
                }
            }
            return request;
        }
    }
}
