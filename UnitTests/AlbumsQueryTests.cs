using FluentAssertions;
using LyrionControl.JsonRpcClient.Queries;
using System.Collections;
using System.Text.Json;

namespace LyrionControl.JsonRpcClient.UnitTests
{
    [TestClass]
    public class AlbumsQueryTests
    {        
        [TestMethod]
        public void AlbumsQuery_IsSerializedToJson_AndMatchesExampleAlbumsQueryStoredAsJsonFile()
        {
            // Arrange            
            var albumsQueryTestData = File.ReadAllText("./AlbumsQuery.json");
            var albumsQuery = new AlbumsQuery(0, 5);
            
            // Act
            var result = JsonSerializer.Serialize(albumsQuery);

            // Assert
            result.Should().Be(albumsQueryTestData);
        }
    }
}