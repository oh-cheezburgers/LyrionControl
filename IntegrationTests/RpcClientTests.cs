using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using System.Collections;
using System.Net;
using FluentAssertions;
using LyrionControl.JsonRpcClient.Responses;
using LyrionControl.JsonRpcClient.Queries;
using System.Text.Json;

namespace LyrionControl.JsonRpcClient.IntegrationTests
{
    [TestClass]
    public class RpcClientTests
    {
        private const int HostPort = 9000;
        private static IContainer? container;

        [ClassInitialize]
        public static async Task ClassInitializeAsync(TestContext context)
        {
            var dir = Directory.GetCurrentDirectory() + "\\TestData";
            container = new ContainerBuilder()
                            .WithImage("lmscommunity/lyrionmusicserver:latest")
                            .WithName("lms")
                            .WithBindMount(Directory.GetCurrentDirectory() + "\\TestData", "/music")
                            .WithPortBinding(3483, 3483)
                            .WithPortBinding(HostPort, HostPort)
                            .WithExposedPort(3483)
                            .WithExposedPort(HostPort)
                            .WithWaitStrategy(Wait.ForWindowsContainer()
                                .UntilHttpRequestIsSucceeded(request => request
                                .ForPort(HostPort).ForPath("/")
                                .ForStatusCode(HttpStatusCode.OK)))
                            .Build();
            await container.StartAsync();
        }

        [TestMethod]
        public async Task MakeRequest_MakesAlbumsRequest_ReturnsAlbumsResponse()
        {
            // Arrange
            var request = new AlbumsQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList()
                {
                    string.Empty,
                    new ArrayList
                    {
                        QueryTypes.Albums,
                        0,
                        5
                    }
                }
            };

            var expected = new AlbumsResponse
            {
                Method = RpcMethod.SlimRequest,
                _Result = new Result
                {
                    AlbumsLoop = null!,
                    Count = 0
                },
                Params = new ArrayList()
                {
                    string.Empty,
                    new List<string>
                    {
                        QueryTypes.Albums,
                        "0",
                        "5"
                    }
                }
            };

            var sut = new RpcClient(new HttpClient { BaseAddress = new Uri($"http://localhost:{HostPort}") });

            // Act
            var result = await sut.MakeRequestAsync<AlbumsResponse>(request);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task MakeRequest_MakesServerStatusRequest_ReturnsServerStatus()
        {
            // Arrange
            var request = new ServerStatusQuery
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
            var expected = new ServerStatusResponse
            {
                _Result = new ServerStatusResponse.Result
                {
                    InfoTotalAlbums = 0,
                    InfoTotalDuration = null,
                    PlayerCount = 0,
                    InfoTotalArtists = 0,
                    HttpPort = container!.GetMappedPublicPort(HostPort),
                    IP = container.IpAddress,
                    InfoTotalSongs = 0,
                    SnPlayerCount = 0,
                    OtherPlayerCount = 0,
                    InfoTotalGenres = 0
                }
            };
            var sut = new RpcClient(new HttpClient { BaseAddress = new Uri($"http://localhost:{HostPort}") });

            // Act
            var actual = await sut.MakeRequestAsync<ServerStatusResponse>(request);

            // Assert
            actual?._Result?.Version.Should().NotBeEmpty();
            actual?._Result?.InfoTotalAlbums.Should().Be(expected._Result.InfoTotalAlbums);
            actual?._Result?.InfoTotalDuration.Should().Be(expected._Result.InfoTotalDuration);
            actual?._Result?.PlayerCount.Should().Be(expected._Result.PlayerCount);
            actual?._Result?.LastScan.Should().Be(0);
            actual?._Result?.InfoTotalArtists.Should().Be(expected._Result.InfoTotalArtists);
            actual?._Result?.HttpPort.Should().Be(expected._Result.HttpPort);
            actual?._Result?.IP.Should().Be(expected._Result.IP);
            actual?._Result?.UUID.Should().NotBeEmpty();
            actual?._Result?.InfoTotalSongs.Should().Be(expected._Result.InfoTotalSongs);
            actual?._Result?.SnPlayerCount.Should().Be(expected._Result.SnPlayerCount);
            actual?._Result?.OtherPlayerCount.Should().Be(expected._Result.OtherPlayerCount);
            actual?._Result?.InfoTotalGenres.Should().Be(expected._Result.InfoTotalGenres);
        }
    }
}