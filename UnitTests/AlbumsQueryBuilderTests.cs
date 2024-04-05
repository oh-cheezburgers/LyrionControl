using FluentAssertions;
using LmsMaui.JsonRpcClient.Builders;
using LmsMaui.JsonRpcClient.Queries;
using System.Collections;

namespace LmsMaui.JsonRpcClient.UnitTests
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
                        start.ToString(),
                        itemsPerResponse.ToString(),
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
