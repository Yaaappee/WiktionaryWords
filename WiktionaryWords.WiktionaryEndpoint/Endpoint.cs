using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WiktionaryWords.WiktionaryEndpoint
{
    public class Endpoint
    {
        private const string ExampleUrl = "http://example.com/";
        private const string WiktionaryApiUrlWithRevIdAndHtml = "https://en.wiktionary.org/w/api.php?action=parse&format=json&prop=text|revid&page=";
        private const string WiktionaryApiUrlWithRevId = "https://en.wiktionary.org/w/api.php?action=parse&format=json&prop=revid&page=";

        private readonly HttpClient _client;

        public Endpoint()
        {
            _client = new HttpClient();
        }

        public Endpoint(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> IsConnectionEstablished()
        {
            var response = await _client.GetAsync(ExampleUrl);
            return response.IsSuccessStatusCode;
        }

        public async Task<WiktionaryEntity> GetRevId(string word)
        {
            return await MakeRequest(WiktionaryApiUrlWithRevId, word);
        }

        public async Task<WiktionaryEntity> GetRevIdAndHtml(string word)
        {
            return await MakeRequest(WiktionaryApiUrlWithRevIdAndHtml, word);
        }

        private async Task<WiktionaryEntity> MakeRequest(string url, string word)
        {
            var response = await _client.GetAsync(url + word);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                if (!(responseString.StartsWith("{\"error\":") || responseString.Contains("invalidtitle")))
                    return JsonConvert.DeserializeObject<WiktionaryEntity>(responseString);
            }

            return null;
        }
    }
}
