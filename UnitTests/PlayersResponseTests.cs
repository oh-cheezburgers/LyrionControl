using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using LyrionControl.JsonRpcClient.Responses;
using static LyrionControl.JsonRpcClient.Responses.PlayersResponse;

namespace LyrionControl.JsonRpcClient.UnitTests
{
    [TestClass]
    public class PlayersResponseTests
    {
        [TestMethod]
        public void PlayersResponse_IsSerializedToJson_AndMatchesExampleAlbumsQueryStoredAsJsonFile()
        {
            // Arrange
            var expected = new PlayersResponse
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
                    Count = 2,
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
            var testData = File.ReadAllText(@".\PlayersResponse.json");
#pragma warning disable CA1869 // Cache and reuse 'JsonSerializerOptions' instances
            var options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            };
#pragma warning restore CA1869 // Cache and reuse 'JsonSerializerOptions' instances
            options.Converters.Add(new ArrayListJsonConverter());

            // Act
            var result = JsonSerializer.Deserialize<PlayersResponse>(testData, options);
            
            // Assert
            expected.Should().BeEquivalentTo(result);
        }
    }
}
