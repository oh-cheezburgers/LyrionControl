using Moq;
using Moq.Contrib.HttpClient;
using System.Collections;
using FluentAssertions;
using LmsMaui.JsonRpcClient.Responses;
using LmsMaui.JsonRpcClient.Queries;
using static LmsMaui.JsonRpcClient.Responses.PlayersResponse;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LmsMaui.JsonRpcClient.Tests
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
            var request = new AlbumsQuery() 
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

            var response = new AlbumsResponse
            {
                Result = new Responses.Result
                {
                    AlbumsLoop = null,
                    Count = 0
                } 
            };

            handler.SetupRequest(HttpMethod.Post, new Uri(mockedServerAddress, RequestUri.Uri))
                .ReturnsJsonResponse(response);

            var sut = new RpcClient(client);

            // Act
            var result = await sut.MakeRequest<AlbumsResponse>(request);

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
                result = new PlayersResponse.Result
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
            handler.SetupRequest(HttpMethod.Post, new Uri(mockedServerAddress, RequestUri.Uri))
                .ReturnsJsonResponse(response, serializeOptions);

            var sut = new RpcClient(client);

            // Act
            

            // Assert
            var actual = await sut.MakeRequest<PlayersResponse>(request);

            actual.Should().BeEquivalentTo(response);
        }
    }
}