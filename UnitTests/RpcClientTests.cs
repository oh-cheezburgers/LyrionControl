using Moq;
using Moq.Contrib.HttpClient;
using System.Collections;
using FluentAssertions;
using LyrionControl.JsonRpcClient.Responses;
using LyrionControl.JsonRpcClient.Queries;
using static LyrionControl.JsonRpcClient.Responses.PlayersResponse;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LyrionControl.JsonRpcClient.Tests
{
    [TestClass()]
    public class RpcClientTests
    {
        private static Uri? mockedServerAddress;
        private static Mock<HttpMessageHandler>? handler;
        private static HttpClient? client;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context) 
        {
            mockedServerAddress = new Uri("http://mocked-server:9000");
            handler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            client = handler.CreateClient();
            client.BaseAddress = mockedServerAddress;        
        }
        
        [TestMethod]
        public async Task MakeRequest_MakesAlbumsRequest_ReturnsAlbumsResponse()
        {
            // Arrange          
            var request = new AlbumsQuery(0, 5);

            var response = new AlbumsResponse
            {
                Result = new Responses.AlbumsResult
                {
                    AlbumsLoop = null,
                    Count = 0
                } 
            };

            handler.SetupRequest(HttpMethod.Post, new Uri(mockedServerAddress!, RequestUri.Uri))
                .ReturnsJsonResponse(response);

            var sut = new RpcClient(client!);

            // Act
            var result = await sut.MakeRequestAsync<AlbumsResponse>(request);

            // Assert
            result.Should().BeEquivalentTo(response);
        }

        [TestMethod]
        public async Task MakeRequest_MakesPlayersRequest_ReturnsAvailablePlayers()
        {
            // Arrange
            var request = new PlayersQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    string.Empty,
                    new List<string>
                    {
                        QueryTypes.Players,
                        "0",
                        "5"
                    }
                }
            };

            var response = new PlayersResponse
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    string.Empty,
                    new List<string>
                    {
                        QueryTypes.Players,
                        "0",
                        "5"
                    }
                },                
                _Result = new PlayersResponse.Result
                {
                    Count = 1,
                    PlayersLoop = new List<Player>
                    {
                        new Player
                        {
                            SeqNo = 0,
                            PlayerId = "70:85:c2:a8:e6:8c",
                            DisplayType = "none",
                            Connected = 1,
                            IP = "192.168.0.21:49877",
                            Model = "squeezelite",
                            Name = "SqueezeLite",
                            Firmware = "v1.9.9-1432",
                            UUID = null,
                            IsPlayer = 1,
                            CanPowerOff = 1,
                            IsPlaying = 0,
                            PlayerIndex = 1,
                            Power = 1,
                            ModelName = "SqueezeLite"
                        },
                        new Player
                        {
                            SeqNo = 0,
                            PlayerId = "bb:bb:15:02:8d:a7",
                            DisplayType = "none",
                            Connected = 1,
                            IP = "192.168.0.21:49830",
                            Model = "squeezelite",
                            Name = "KEF LSX",
                            Firmware = "0",
                            UUID = null,
                            IsPlayer = 1,
                            CanPowerOff = 1,
                            IsPlaying = 0,
                            PlayerIndex = 0,
                            Power = 1,
                            ModelName = "UPnPBridge"
                        }
                    }
                }
                
            };
            
            var serializeOptions = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            };
            handler.SetupRequest(HttpMethod.Post, new Uri(mockedServerAddress!, RequestUri.Uri))
                .ReturnsJsonResponse(response, serializeOptions);

            var sut = new RpcClient(client!);

            // Act
            

            // Assert
            var actual = await sut.MakeRequestAsync<PlayersResponse>(request);

            actual.Should().BeEquivalentTo(response);
        }
    }
}