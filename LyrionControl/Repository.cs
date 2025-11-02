using LyrionControl.JsonRpcClient.Responses;
using LyrionControl.JsonRpcClient.Builders;

namespace LyrionControl.JsonRpcClient
{
    public class Repository
    {
        private readonly HttpClient httpClient;
        private readonly RpcClient rpcClient;
        public Repository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.rpcClient = new RpcClient(httpClient);
        }
        public Task<AlbumsResponse?> GetAllAlbumsAsync()
        {   
            var request = new AlbumsQueryBuilder().Start(0)
                .ItemsPerResponse(1000)
                .WithTitle()
                .WithArtworTrackId()
                .Build();

            return rpcClient.MakeRequestAsync<AlbumsResponse>(request);
        }

        public Task<AlbumsResponse?> GetAlbumsByArtistIdAsync(string id)
        {
            var request = new AlbumsQueryBuilder().Start(0)
               .ItemsPerResponse(1000)
               .ByArtistId(id)
               .WithTitle()
               .WithArtworTrackId()
               .Build();

            return rpcClient.MakeRequestAsync<AlbumsResponse>(request);
        }

        public Task<SongsResponse?> GetSongsAsync(int albumId) 
        {
            var request = new SongsQueryBuilder().Start(0)
                .ItemsPerResponse(100)
                .WithAlbumId(albumId)
                .WithTrackNumber()
                .WithDuration()
                .WithUrl()
                .Build();

            return rpcClient.MakeRequestAsync<SongsResponse>(request);
        }

        public Task<ServerStatusResponse?> GetServerStatusAsync() 
        { 
            var request = new ServerStatusQueryBuilder().Start(0).ItemsPerResponse(1).Build();

            return rpcClient.MakeRequestAsync<ServerStatusResponse>(request);
        }

        public Task<StatusResponse?> GetPlayerStatusAsync(string playerId) 
        {
            var request = new StatusQueryBuilder(playerId).Build();

            return rpcClient.MakeRequestAsync<StatusResponse>(request);
        }

        public Task<ArtistsResponse?> GetArtistsAsync()
        {
            var request = new ArtistsQueryBuilder().Start(0).ItemsPerResponse(1000).WithRoleId("ALBUMARTIST").Build();
            return rpcClient.MakeRequestAsync<ArtistsResponse>(request);
        }

        public Task<ArtistsResponse?> SearchArtistsAsync(string term)
        {
            var request = new ArtistsQueryBuilder().Start(0).ItemsPerResponse(1000).WithRoleId("ALBUMARTIST").WithSearchTerm(term).Build();
            return rpcClient.MakeRequestAsync<ArtistsResponse>(request);
        }

        public Task<AlbumsResponse?> SearchAlbumsAsync(string term)
        {
            var request = new AlbumsQueryBuilder().Start(0).ItemsPerResponse(1000).WithArtworTrackId().WithSearchTerm(term).Build();
            return rpcClient.MakeRequestAsync<AlbumsResponse>(request);
        }

        public Task<SongsResponse?> SearchSongsAsync(string term)
        {
            var request = new SongsQueryBuilder().Start(0).ItemsPerResponse(1000).WithUrl().WithAlbumIdTag().WithArtworTrackId().WithSearchTerm(term).Build();
            return rpcClient.MakeRequestAsync<SongsResponse>(request);
        }
    }
}
