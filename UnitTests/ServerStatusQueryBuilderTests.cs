using FluentAssertions;
using LmsMaui.JsonRpcClient.Builders;
using LmsMaui.JsonRpcClient.Queries;
using System.Collections;

namespace LmsMaui.JsonRpcClient.UnitTests
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
