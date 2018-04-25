using Xunit;

namespace WiktionaryWords.WiktionaryEndpoint.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var exampleConnection = await Example.IsConnectionEstablished();
            Assert.True(exampleConnection);
        }
    }
}
