using FluentAssertions;
using LyrionControl.JsonRpcClient.Builders;
using LyrionControl.JsonRpcClient.Queries;
using System.Collections;

namespace LyrionControl.JsonRpcClient.UnitTests
{
    [TestClass]
    public class ServerStatusQueryBuilderTests
    {
        [TestMethod]
        public void Build_WhenCalled_ReturnsServerStatusQuery()
        {
            // Arrange
            var expected = new ServerStatusQuery
            {
                Method = RpcMethod.SlimRequest,
                Params = new ArrayList
                {
                    string.Empty,
                    new ArrayList
                    {
                        QueryTypes.ServerStatus
                    }
                }
            };            
            
            var sut = new ServerStatusQueryBuilder();

            // Act
            var result = sut.Build();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
