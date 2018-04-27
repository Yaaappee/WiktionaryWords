using Xunit;

namespace WiktionaryWords.WiktionaryEndpoint.Tests
{
    public class EndpointTests
    {
        [Fact]
        public async void TestInternetConnection()
        {
            var endpoint = new Endpoint();
            var exampleConnection = await endpoint.IsConnectionEstablished();
            Assert.True(exampleConnection);
        }

        [Fact]
        public async void TestWordInfo()
        {
            var word = "get";
            var endpoint = new Endpoint();
            var entity = await endpoint.GetRevIdAndHtml(word);
            Assert.NotNull(entity);
            Assert.NotNull(entity.Parse.Text.Html);
            Assert.Contains(word, entity.Parse.Text.Html);
            Assert.Contains(word, entity.Parse.Title);
            Assert.NotEqual(0, entity.Parse.RevId);
        }

        [Fact]
        public async void TestWordHtml()
        {
            var word = "get";
            var endpoint = new Endpoint();
            var entity = await endpoint.GetRevId(word);
            Assert.NotNull(entity);
            Assert.Equal(word, entity.Parse.Title);
            Assert.NotEqual(0, entity.Parse.RevId);
        }

        [Fact]
        public async void TestWordHtml2()
        {
            var word = "";
            var endpoint = new Endpoint();
            var html = await endpoint.GetRevId(word);
            Assert.Null(html);
        }

        [Fact]
        public async void TestWordHtml3()
        {
            var word = "";
            var endpoint = new Endpoint();
            var html = await endpoint.GetRevIdAndHtml(word);
            Assert.Null(html);
        }
    }
}
