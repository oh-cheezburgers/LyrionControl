using FluentAssertions;
using LyrionControl.JsonRpcClient.Builders;
using LyrionControl.JsonRpcClient.Queries;
using System.Collections;
using System.Globalization;

namespace LyrionControl.JsonRpcClient.UnitTests
{
    [TestClass]
    public class AlbumsQueryBuilderTests
    {
        [TestMethod]
        public void Build_WhenCalled_ReturnsAlbumsQuery()
        {
            // Arrange
            var start = 0;
            var itemsPerResponse = 5;

            var expected = new AlbumsQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    "",
                    new List<string>
                    {
                        QueryTypes.Albums,
                        start.ToString(CultureInfo.InvariantCulture),
                        itemsPerResponse.ToString(CultureInfo.InvariantCulture),
                        "tags: t,j"
                    }
                }
            };

            var sut = new AlbumsQueryBuilder().Start(start)
                .ItemsPerResponse(itemsPerResponse)
                .WithTitle()
                .WithArtworTrackId();


            // Act
            var result = sut.Build();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
