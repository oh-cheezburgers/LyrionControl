using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using System.Collections;
using System.Net;
using FluentAssertions;
using LmsMaui.JsonRpcClient.Responses;
using LmsMaui.JsonRpcClient.Queries;
using System.Text.Json;

namespace LmsMaui.JsonRpcClient.IntegrationTests
{
    [TestClass]
    public class RpcClientTests
    {
        private const int HostPort = 9000;
        private static IContainer container;

        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {
            var dir = Directory.GetCurrentDirectory() + "\\TestData";
            container = new ContainerBuilder()
                            .WithImage("lmscommunity/logitechmediaserver:latest")
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
                Result = new Result
                {
                    AlbumsLoop = null,
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
            var result = await sut.MakeRequest<AlbumsResponse>(request);

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
                result = new ServerStatusResponse.Result
                {
                    InfoTotalAlbums = 0,
                    InfoTotalDuration = null,
                    PlayerCount = 0,
                    InfoTotalArtists = 0,
                    HttpPort = container.GetMappedPublicPort(HostPort).ToString(),
                    IP = container.IpAddress,
                    InfoTotalSongs = 0,
                    SnPlayerCount = 0,
                    OtherPlayerCount = 0,
                    InfoTotalGenres = 0
                }
            };
            var sut = new RpcClient(new HttpClient { BaseAddress = new Uri($"http://localhost:{HostPort}") });

            // Act
            var actual = await sut.MakeRequest<ServerStatusResponse>(request);

            // Assert
            actual.result.Version.Should().NotBeEmpty();
            actual.result.InfoTotalAlbums.Should().Be(expected.result.InfoTotalAlbums);
            actual.result.InfoTotalDuration.Should().Be(expected.result.InfoTotalDuration);
            actual.result.PlayerCount.Should().Be(expected.result.PlayerCount);
            actual.result.LastScan.Should().Be(expected.result.LastScan);
            actual.result.InfoTotalArtists.Should().Be(expected.result.InfoTotalArtists);
            actual.result.HttpPort.Should().Be(expected.result.HttpPort);
            actual.result.IP.Should().Be(expected.result.IP);
            actual.result.UUID.Should().NotBeEmpty();
            actual.result.InfoTotalSongs.Should().Be(expected.result.InfoTotalSongs);
            actual.result.SnPlayerCount.Should().Be(expected.result.SnPlayerCount);
            actual.result.OtherPlayerCount.Should().Be(expected.result.OtherPlayerCount);
            actual.result.InfoTotalGenres.Should().Be(expected.result.InfoTotalGenres);
        }
    }
}