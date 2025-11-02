# LmsRpcClient

A .NET 8 library for communicating with Lyrion Music Servers (formerly Logitech Media Server/Squeezebox Server) via JSON-RPC. This client provides a strongly-typed interface for querying server information, managing players, and retrieving music library data.

## Features

- Query server status and information
- Retrieve albums, artists, and songs from the music library
- Get player status and information
- Search functionality for albums and artists
- Strongly-typed responses with JSON deserialization
- Fluent query builders for complex requests
- Support for pagination and filtering

## Usage

### Basic Setup

```csharp
using LyrionControl.JsonRpcClient;

var httpClient = new HttpClient 
{ 
  BaseAddress = new Uri("http://your-lyrion-server:9000") 
};

var repository = new Repository(httpClient);
```

### Get Server Status

```csharp
var serverStatus = await repository.GetServerStatus();

Console.WriteLine($"Server Version: {serverStatus.result.Version}");
Console.WriteLine($"Total Albums: {serverStatus.result.InfoTotalAlbums}");
Console.WriteLine($"Total Artists: {serverStatus.result.InfoTotalArtists}");
Console.WriteLine($"Total Songs: {serverStatus.result.InfoTotalSongs}");
Console.WriteLine($"Player Count: {serverStatus.result.PlayerCount}");
```

### Retrieve Music Library Data

```csharp
// Get all artists
var artists = await repository.GetArtists();
foreach (var artist in artists.Result.ArtistsLoop)
{
 Console.WriteLine($"Artist: {artist.Artist}");
}

// Get all albums
var albums = await repository.GetAllAlbums();
foreach (var album in albums.Result.AlbumsLoop)
{
    Console.WriteLine($"Album: {album.Title}");
}

// Get albums by specific artist
var artistAlbums = await repository.GetAlbumsByArtistId("123");

// Get songs from an album
var songs = await repository.GetSongs(albumId: 456);
foreach (var song in songs.result.TitlesLoop)
{
    Console.WriteLine($"Track {song.TrackNum}: {song.Title} ({song.Duration})");
}
```

### Search Functionality

```csharp
// Search for artists
var searchResults = await repository.SearchArtists("Beatles");

// Search for albums
var albumResults = await repository.SearchAlbums("Abbey Road");
```

### Player Management

```csharp
// Get player status
var playerStatus = await repository.GetPlayerStatus("player-id");
Console.WriteLine($"Player: {playerStatus.result.CurrentTitle}");
```

### Advanced Usage with RpcClient

```csharp
using LyrionControl.JsonRpcClient.Builders;
using LyrionControl.JsonRpcClient.Responses;

var rpcClient = new RpcClient(httpClient);

// Build custom queries using fluent builders
var customAlbumsQuery = new AlbumsQueryBuilder()
    .Start(0)
    .ItemsPerResponse(50)
  .WithTitle()
    .WithArtworTrackId()
    .Build();

var response = await rpcClient.MakeRequest<AlbumsResponse>(customAlbumsQuery);
```

## Requirements

- .NET 8.0 or later
- Access to a Lyrion Music Server (LMS) instance

## Building

```sh
dotnet build
dotnet test
```

## Integration Testing

The library includes integration tests that use Docker containers to test against a real Lyrion Music Server instance:

```sh
# Run integration tests (requires Docker)
dotnet test --filter "Category=Integration"
```

## API Coverage

The library supports the following LMS JSON-RPC commands:

- `serverstatus` - Get server information and status
- `albums` - Query album information
- `artists` - Query artist information  
- `songs` - Query song/track information
- `status` - Get player status
- `players` - Get connected players

Each command supports various parameters for filtering, pagination, and selecting specific data fields.