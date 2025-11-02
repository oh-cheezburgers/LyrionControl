using FluentAssertions;
using LyrionControl.JsonRpcClient.Builders;
using LyrionControl.JsonRpcClient.Queries;
using System.Collections;

namespace LyrionControl.JsonRpcClient.UnitTests
{
    [TestClass]
    public class PlayersQueryBuilderTests
    {
        [TestMethod]
        public void Build_WhenCalled_ReturnsPlayersQuery()
        {
            // Arrange
            var expected = new PlayersQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    string.Empty,
                    new ArrayList
                    {
                        QueryTypes.Players,
                        0,
                        5
                    }
                }
            };            
            
            var sut = new PlayersQueryBuilder().Start(0).ItemsPerResponse(5);

            // Act
            var actual = sut.Build();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
