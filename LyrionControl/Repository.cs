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
        public Task<AlbumsResponse> GetAllAlbums()
        {   
            var request = new AlbumsQueryBuilder().Start(0)
                .ItemsPerResponse(1000)
                .WithTitle()
                .WithArtworTrackId()
                .Build();

            return rpcClient.MakeRequest<AlbumsResponse>(request);
        }

        public Task<AlbumsResponse> GetAlbumsByArtistId(string id)
        {
            var request = new AlbumsQueryBuilder().Start(0)
               .ItemsPerResponse(1000)
               .ByArtistId(id)
               .WithTitle()
               .WithArtworTrackId()
               .Build();

            return rpcClient.MakeRequest<AlbumsResponse>(request);
        }

        public Task<SongsResponse> GetSongs(int albumId) 
        {
            var request = new SongsQueryBuilder().Start(0)
                .ItemsPerResponse(100)
                .WithAlbumId(albumId)
                .WithTrackNumber()
                .WithDuration()
                .WithUrl()
                .Build();

            return rpcClient.MakeRequest<SongsResponse>(request);
        }

        public Task<ServerStatusResponse> GetServerStatus() 
        { 
            var request = new ServerStatusQueryBuilder().Start(0).ItemsPerResponse(1).Build();

            return rpcClient.MakeRequest<ServerStatusResponse>(request);
        }

        public Task<StatusResponse> GetPlayerStatus(string playerId) 
        {
            var request = new StatusQueryBuilder(playerId).Build();

            return rpcClient.MakeRequest<StatusResponse>(request);
        }

        public Task<ArtistsResponse> GetArtists()
        {
            var request = new ArtistsQueryBuilder().Start(0).ItemsPerResponse(1000).WithRoleId("ALBUMARTIST").Build();
            return rpcClient.MakeRequest<ArtistsResponse>(request);
        }

        public Task<ArtistsResponse> SearchArtists(string term)
        {
            var request = new ArtistsQueryBuilder().Start(0).ItemsPerResponse(1000).WithRoleId("ALBUMARTIST").WithSearchTerm(term).Build();
            return rpcClient.MakeRequest<ArtistsResponse>(request);
        }

        public Task<AlbumsResponse> SearchAlbums(string term)
        {
            var request = new AlbumsQueryBuilder().Start(0).ItemsPerResponse(1000).WithArtworTrackId().WithSearchTerm(term).Build();
            return rpcClient.MakeRequest<AlbumsResponse>(request);
        }

        public Task<SongsResponse> SearchSongs(string term)
        {
            var request = new SongsQueryBuilder().Start(0).ItemsPerResponse(1000).WithUrl().WithAlbumIdTag().WithArtworTrackId().WithSearchTerm(term).Build();
            return rpcClient.MakeRequest<SongsResponse>(request);
        }
    }
}
