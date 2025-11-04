using FluentAssertions;
using LyrionControl.JsonRpcClient.Builders;
using LyrionControl.JsonRpcClient.Queries;
using System.Collections;

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

            var expected = new AlbumsQuery(start, itemsPerResponse)
            {
                Params = new ArrayList
                {
                    string.Empty,
                    new ArrayList
                    {
                        QueryTypes.Albums,
                        start,
                        itemsPerResponse,
                        "tags: t,j"
                    }
                }
            };

            var sut = new AlbumsQueryBuilder(0, 5)
                .WithTitle()
                .WithArtworTrackId();


            // Act
            var result = sut.Build();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
