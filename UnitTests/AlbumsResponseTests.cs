using System.Text.Json;
using LyrionControl.JsonRpcClient.Responses;

namespace LyrionControl.JsonRpcClient.UnitTests
{
    [TestClass]
    public class AlbumsResponseTests
    {
        [TestMethod]
        public void AlbumsResponse_IsSerializedToJson_AndMatchesExampleAlbumsQueryStoredAsJsonFile()
        {
            // Arrange
            var testData = File.ReadAllText(@".\AlbumsResponse.json");
            
            // Act
            var result = JsonSerializer.Deserialize<AlbumsResponse>(testData);
            
            // Assert
            var first = result.Result;
        }
    }
}
